namespace Feliz.Konva

open Feliz
open Fable.Core.JsInterop
open Fable.Core

type Event = Browser.Types.Event

[<Erase>]
type layer =

    static member inline rect(props: IRectProp seq) =
        Interop.reactApi.createElement (Interop.rect, createObj !!props)
    static member inline key(key: string) : IKonvaProp = Interop.mkKonvaProp "key" key
    static member inline children(children: ReactElement list) =
        unbox<ILayerProp> (prop.children children)
