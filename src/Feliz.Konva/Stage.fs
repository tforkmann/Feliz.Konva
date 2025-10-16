namespace Feliz.Konva

open Feliz
open Fable.Core.JsInterop
open Fable.Core

[<Erase>]
type stage =
    static member inline style (props: IKonvaStylesProp seq) : IStageProp = Interop.mkStageProp "style" (createObj !!props)

    static member inline children(children: ReactElement list) =
        unbox<IStageProp> (prop.children children)
    static member inline width(width: float) : IStageProp = Interop.mkStageProp "width" width
    static member inline height(height: float) : IStageProp = Interop.mkStageProp "height" height
