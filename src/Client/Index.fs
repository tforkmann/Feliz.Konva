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

let view (model: Model) (dispatch: Msg -> unit) =
    // let format = "d.m.Y H:i"
    let format = "d.m.Y"

    Konva.stage [
        stage.width 500
        stage.height 500
        stage.children [
            Konva.layer [
                layer.children [
                    Konva.rect [ rect.x 100; rect.y 100; rect.width 200; rect.height 200; rect.fill "red" ]
                    Konva.circle [ circle.x 100; circle.y 100; circle.radius 50; circle.fill "green" ]
                ]
            ]
        ]
    ]
