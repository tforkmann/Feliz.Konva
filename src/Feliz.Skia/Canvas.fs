namespace Feliz.Konva

open Feliz
open Fable.Core.JsInterop
open Fable.Core

[<Erase>]
type Canvas =
    static member inline style (props: IKonvaStylesProp seq) : ICanvasProp = Interop.mkCanvasProp "style" (createObj !!props)

    static member inline children(children: ReactElement list) =
        unbox<ICanvasProp> (prop.children children)
