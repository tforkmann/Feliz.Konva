namespace Feliz.Konva

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    let inline mkKonvaProp (key: string) (value: obj) : IKonvaProp = unbox (key, value)
    let inline mkStageProp (key: string) (value: obj) : IStageProp = unbox (key, value)
    let inline mkLayerProp (key: string) (value: obj) : IStageProp = unbox (key, value)
    let inline mkRectProp (key: string) (value: obj) : IRectProp = unbox (key, value)
    let inline mkCircleProp (key: string) (value: obj) : ICircleProp = unbox (key, value)
    let inline mkStylesProp (key: string) (value: obj) : IKonvaStylesProp = unbox (key, value)
    let inline mkOptionsProp (key: string) (value: obj) : IOptionsProp = unbox (key, value)


    let stage: obj = import "Stage" "react-konva"
    let layer: obj = import "Layer" "react-konva"
    let circle: obj = import "Circle" "react-konva"
    let text: obj = import "Text" "react-konva"
    let rect: obj = import "Rect" "react-konva"
