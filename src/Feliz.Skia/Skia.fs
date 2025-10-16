namespace Feliz.Konva

open Feliz
open Fable.Core.JsInterop
open Fable.Core

type Event = Browser.Types.Event

[<Erase>]
type Konva =

    static member inline canvas(props: ReactElement seq) =
        Interop.reactApi.createElement (Interop.canvas, createObj !!props)
    static member inline rect(props: IRectProp seq) =
        Interop.reactApi.createElement (Interop.rect, createObj !!props)
