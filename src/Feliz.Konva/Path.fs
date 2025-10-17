namespace Feliz.Konva

open Fable.Core
open Fable.React
[<Erase>]
type path =
    static member inline data(v: string) : IPathProp = Interop.mkPathProp "data" v
    static member inline stroke(color: string) : IPathProp = Interop.mkPathProp "stroke" color
    static member inline strokeWidth(v: float) : IPathProp = Interop.mkPathProp "strokeWidth" v
    static member inline fill(color: string) : IPathProp = Interop.mkPathProp "fill" color
    static member inline opacity(v: float) : IPathProp = Interop.mkPathProp "opacity" v
    static member inline lineCap(v: string) : IPathProp = Interop.mkPathProp "lineCap" v
    static member inline lineJoin(v: string) : IPathProp = Interop.mkPathProp "lineJoin" v
    static member inline rotation(v: float) : IPathProp = Interop.mkPathProp "rotation" v
    static member inline x(v: float) : IPathProp = Interop.mkPathProp "x" v
    static member inline y(v: float) : IPathProp = Interop.mkPathProp "y" v
    static member inline ref(v: IRefValue<'a>) : IPathProp = Interop.mkPathProp "ref" v
