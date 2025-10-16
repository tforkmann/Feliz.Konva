namespace Feliz.Konva

open Fable.Core

[<Erase>]
type text =
    static member inline x(x: float) : ITextProp = Interop.mkTextProp "x" x
    static member inline y(y: float) : ITextProp = Interop.mkTextProp "y" y
    static member inline text(text: string) : ITextProp = Interop.mkTextProp "text" text
    static member inline fontSize(fontSize: float) : ITextProp = Interop.mkTextProp "fontSize" fontSize
    static member inline fontFamily(fontFamily: string) : ITextProp = Interop.mkTextProp "fontFamily" fontFamily
    static member inline fill(fill: string) : ITextProp = Interop.mkTextProp "fill" fill
