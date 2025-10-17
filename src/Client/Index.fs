module Index

open Elmish
open Feliz
open Feliz.Konva
open System
open Fable.Core.JsInterop

type Model = { Date: DateTime }

type Msg =
    | SetStartDate of DateTime
    | SetEndDate of DateTime

let init () = { Date = DateTime.Now }, Cmd.none

let update msg (model: Model) =
    match msg with
    | SetStartDate date -> { model with Date = date }, Cmd.none
    | SetEndDate date -> { model with Date = date }, Cmd.none

let private renderWithClearButton: obj * obj -> ReactElement =
    fun (args, ref) ->
        Html.div [
            Html.input [
                prop.custom ("ref", ref)
                prop.defaultValue (unbox<string> args?defaultValue)
                prop.className "flatpickr-input"
            ]
            Html.button [
                prop.className "flatpickr-clear-button"
                prop.text "Clear"
                prop.onClick (fun ev ->
                    let target = ev.target :?> Browser.Types.HTMLElement
                    // the button’s previous sibling is the input
                    let input = target.previousElementSibling :?> Browser.Types.HTMLElement

                    if not (isNullOrUndefined input) then
                        let fp = input?_flatpickr

                        if not (isNull fp) then
                            fp?clear ()
                            fp?close ())
            ]
        ]

[<ReactComponent>]
let KonvaImageFromUrl (url: string, x: float, y: float, w: float, h: float) =
    try
        let imageElement, setImage = React.useState None

        React.useEffect (
            (fun () ->
                printfn "Effect triggered for loading image from %s" url

                let img =
                    Browser.Dom.document.createElement ("img") :?> Browser.Types.HTMLImageElement

                img.crossOrigin <- "Anonymous"
                img.src <- url

                img.onload <-
                    fun _ ->
                        printfn "Image loaded from %s" url
                        setImage (Some img)

                None),
            [| box url |]
        )


        match imageElement with
        | None ->
            printfn "Loading image from %s" url
            Html.none
        | Some img ->
            printfn "Rendering image from %s" url
            Konva.image [ image.x x; image.y y; image.width w; image.height h; image.image img ]
    with ex ->
        printfn "Error loading image from %s: %s" url ex.Message
        Html.none

let arcPath = "M100,50 A50,50 0 0,1 150,100" // simple quarter arc

let makeArc (cx: float, cy: float, radius: float, startDeg: float, sweepDeg: float) =
    let toRad deg = deg * System.Math.PI / 180.0
    let startR = toRad startDeg
    let endR = toRad (startDeg + sweepDeg)
    let x1 = cx + radius * cos startR
    let y1 = cy + radius * sin startR
    let x2 = cx + radius * cos endR
    let y2 = cy + radius * sin endR
    let largeArc = if sweepDeg > 180.0 then 1 else 0
    let sweep = 1
    $"M{x1},{y1} A{radius},{radius} 0 {largeArc},{sweep} {x2},{y2}"

let connectorArc (cx, cy, radius, startDeg, sweepDeg, color) =
    Konva.path [
        path.data (makeArc (cx, cy, radius, startDeg, sweepDeg))
        path.stroke color
        path.strokeWidth 8
        path.lineCap "round"
    ]

let connectors = 6
let gap = 10.0
let sweep = (360.0 / float connectors) - gap
let r = 80.0
let cx, cy = 300.0, 100.0

let gauge = [
    for i in 0 .. connectors - 1 ->
        let start = -90.0 + float i * (sweep + gap)

        let color =
            match i with
            | 0
            | 1 -> "#22c55e" // available
            | 2 -> "#eab308" // unavailable
            | _ -> "#ef4444" // disabled

        connectorArc (cx, cy, r, start, sweep, color)
]

type ChargerGaugeProps = {
    Connectors: int
    Available: int
    Disabled: int
    CenterX: float
    CenterY: float
    Radius: float
    PowerLabel: string option
    PriceLabel: string option
    SvgUrl: string option
}

[<ReactComponent>]
let ChargerGauge (props: ChargerGaugeProps) =
    let unavailable = connectors - props.Available - props.Disabled
    let gap = 10.0
    let sweep = 360.0 / float connectors - gap

    let colorFor i =
        if i < props.Available then "#22c55e"
        elif i < props.Available + unavailable then "#eab308"
        else "#ef4444"

    // animate each arc as it appears
    let animatedArc (i: int) =
        let pathRef = React.useRef None
        let start = -90.0 + float i * (sweep + gap)
        let color = colorFor i

        React.useEffect(
            (fun () ->
                match pathRef.current with
                | Some node ->

                    let tween =
                        Konva.createTween [
                            tween.node node
                            tween.duration 0.1
                            tween.easing (fun t -> t ** 1.0) // custom ease-in quadratic
                            tween.opacity 1.0
                            tween.strokeWidth 8.0
                            ]
                    // delay slightly per index for a cascading effect
                    Fable.Core.JS.setTimeout (fun () -> tween.play()) (i * 20) |> ignore
                | None -> ()
                None),
            [||]
        )
        Konva.path [
            path.ref pathRef
            path.opacity 0.0
            path.data (makeArc (props.CenterX, props.CenterY, props.Radius, start, sweep))
            path.stroke color
            path.strokeWidth 8
            path.lineCap "round"
        ]
    let arcs = [ for i in 0 .. props.Connectors - 1 -> animatedArc i ]

    Konva.layer [
        layer.children [
            // gauge arcs
            yield! arcs

            // center SVG
            match props.SvgUrl with
            | Some url -> yield KonvaImageFromUrl(url, props.CenterX - 25.0, props.CenterY - 25.0, 50.0, 50.0)
            | None -> ()

            // power label
            match props.PowerLabel with
            | Some p ->
                yield
                    Konva.text [
                        text.x (props.CenterX - 30.0)
                        text.y (props.CenterY + props.Radius + 10.0)
                        text.text p
                        text.fontSize 16
                        text.fill "#000"
                        text.fontFamily "Calibri"
                    ]
            | None -> ()

            // price label
            match props.PriceLabel with
            | Some pr ->
                yield
                    Konva.text [
                        text.x (props.CenterX - 30.0)
                        text.y (props.CenterY + props.Radius + 30.0)
                        text.text pr
                        text.fontSize 14
                        text.fill "#666"
                        text.fontFamily "Calibri"
                    ]
            | None -> ()
        ]
    ]

let view (model: Model) (dispatch: Msg -> unit) =
    // let format = "d.m.Y H:i"
    let format = "d.m.Y"

    Konva.stage [
        stage.width 500
        stage.height 500
        stage.children [
            ChargerGauge {
                Connectors = 6
                Available = 3
                Disabled = 2
                CenterX = 250.0
                CenterY = 150.0
                Radius = 80.0
                PowerLabel = Some "50 kW"
                PriceLabel = Some "0.35 $/kWh"
                SvgUrl = Some "https://konvajs.org/assets/yoda.jpg"
            }
        ]
    ]
