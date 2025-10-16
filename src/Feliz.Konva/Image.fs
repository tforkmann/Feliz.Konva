namespace Feliz.Konva

open Fable.Core

[<Erase>]
type image =
    static member inline x(value: float) : IImageProp = Interop.mkImageProp "x" value
    static member inline y(value: float) : IImageProp = Interop.mkImageProp "y" value
    static member inline width(value: float) : IImageProp = Interop.mkImageProp "width" value
    static member inline height(value: float) : IImageProp = Interop.mkImageProp "height" value
    static member inline image(image: Browser.Types.HTMLImageElement) : IImageProp = Interop.mkImageProp "image" image
