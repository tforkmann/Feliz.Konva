namespace Feliz.Konva

open Fable.Core

[<Erase>]
type rect =
    static member inline x(x: float) : IRectProp = Interop.mkRectProp "x" x
    static member inline y(y: float) : IRectProp = Interop.mkRectProp "y" y
    static member inline width(width: float) : IRectProp = Interop.mkRectProp "width" width
    static member inline height(height: float) : IRectProp = Interop.mkRectProp "height" height
    static member inline fill(fill: string) : IRectProp = Interop.mkRectProp "fill" fill
    static member inline rx(rx: float) : IRectProp = Interop.mkRectProp "rx" rx
    static member inline ry(ry: float) : IRectProp = Interop.mkRectProp "ry" ry
