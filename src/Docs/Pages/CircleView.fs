module Docs.Pages.CircleView

open Feliz
open Feliz.Konva
open Docs.SharedView
open System
open Feliz.UseElmish
open Elmish

type Msg =
    | SetStartDate of DateTimeOffset
    | SetEndDate of DateTimeOffset

type State =
    { StartDate: DateTimeOffset
      EndDate: DateTimeOffset }

let init () =
    {
        StartDate = DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero)
        EndDate = DateTimeOffset(2019, 1, 31, 0, 0, 0, TimeSpan.Zero)
    },
    Cmd.none

let update msg (model: State) =
    match msg with
    | SetStartDate date -> { model with StartDate = date }, Cmd.none
    | SetEndDate date -> { model with EndDate = date }, Cmd.none

let Circle (state: State) (dispatch: Msg -> unit) =
    let now = DateTime.Now

    Html.div [
        prop.style [ style.height 600; style.width 600 ]
        prop.children [
            Konva.stage [
                stage.width 600
                stage.height 600
                stage.children [
                    Konva.layer [
                        layer.children [
                            Konva.circle [
                                circle.x 300
                                circle.y 300
                                circle.radius 100
                                circle.fill "red"
                            ]
                        ]
                    ]
                ]
        ]
        ]
    ]


let code =
    """
    Konva.stage [
        stage.width 600
        stage.height 600
        stage.children [
            Konva.layer [
                layer.children [
                    Konva.circle [
                        circle.x 300
                        circle.y 300
                        circle.radius 100
                        circle.fill "red"
                    ]
                ]
            ]
        ]
    ]
    """

let title = Html.text "Circle"

[<ReactComponent>]
let CircleView () =
    let state,dispatch = React.useElmish(init, update, [||])
    Html.div [
        codedView title code (Circle state dispatch)
        fixDocsView "Circle" false
    ]
