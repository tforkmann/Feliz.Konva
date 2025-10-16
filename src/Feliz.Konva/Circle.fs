namespace Feliz.Konva

open Fable.Core

[<Erase>]
type circle =
    static member inline x(x: float) : ICircleProp = Interop.mkCircleProp "x" x
    static member inline y(y: float) : ICircleProp = Interop.mkCircleProp "y" y
    static member inline radius(radius: float) : ICircleProp = Interop.mkCircleProp "radius" radius
    static member inline fill(fill: string) : ICircleProp = Interop.mkCircleProp "fill" fill
    static member inline stroke(stroke: string) : ICircleProp = Interop.mkCircleProp "stroke" stroke
    static member inline strokeWidth(strokeWidth: float) : ICircleProp = Interop.mkCircleProp "strokeWidth" strokeWidth
