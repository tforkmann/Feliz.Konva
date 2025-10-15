namespace Feliz.Skia

open Feliz
open Fable.Core.JsInterop
open Fable.Core

[<Erase>]
type Canvas =
    static member inline style (props: ISkiaStylesProp seq) : ICanvasProp = Interop.mkCanvasProp "style" (createObj !!props)

    static member inline children(children: ReactElement list) =
        unbox<ICanvasProp> (prop.children children)
