namespace Feliz.Konva

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    let inline mkKonvaProp (key: string) (value: obj) : IKonvaProp = unbox (key, value)
    let inline mkCanvasProp (key: string) (value: obj) : ICanvasProp = unbox (key, value)
    let inline mkRectProp (key: string) (value: obj) : IRectProp = unbox (key, value)
    let inline mkCircleProp (key: string) (value: obj) : ICircleProp = unbox (key, value)
    let inline mkStylesProp (key: string) (value: obj) : IKonvaStylesProp = unbox (key, value)
    let inline mkOptionsProp (key: string) (value: obj) : IOptionsProp = unbox (key, value)

    let skia: obj = importAll "react-konva/lib/module/web"

    let canvas: obj = import "Canvas" "react-konva/lib/module"
    let circle: obj = import "Circle" "react-konva/lib/module"
    let rect:   obj = import "Rect"   "react-konva/lib/module"
    skia?LoadKonvaWeb()
