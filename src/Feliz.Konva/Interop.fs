namespace Feliz.Konva

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    let inline mkKonvaProp (key: string) (value: obj) : IKonvaProp = unbox (key, value)
    let inline mkTweenProp (key: string) (value: obj) : ITweenProp = unbox (key, value)
    let inline mkStageProp (key: string) (value: obj) : IStageProp = unbox (key, value)
    let inline mkLayerProp (key: string) (value: obj) : IStageProp = unbox (key, value)
    let inline mkRectProp (key: string) (value: obj) : IRectProp = unbox (key, value)
    let inline mkCircleProp (key: string) (value: obj) : ICircleProp = unbox (key, value)
    let inline mkTextProp (key: string) (value: obj) : ITextProp = unbox (key, value)
    let inline mkImageProp (key: string) (value: obj) : IImageProp = unbox (key, value)
    let inline mkPathProp (key: string) (value: obj) : IPathProp = unbox (key, value)
    let inline mkStylesProp (key: string) (value: obj) : IKonvaStylesProp = unbox (key, value)
    let inline mkOptionsProp (key: string) (value: obj) : IOptionsProp = unbox (key, value)

    let Stage: Feliz.ReactElement = import "Stage" "react-konva"
    let Layer: Feliz.ReactElement = import "Layer" "react-konva"
    let Circle: Feliz.ReactElement = import "Circle" "react-konva"
    let Text: Feliz.ReactElement = import "Text" "react-konva"
    let Rect: Feliz.ReactElement = import "Rect" "react-konva"
    let Image: Feliz.ReactElement = import "Image" "react-konva"
    let Path: Feliz.ReactElement = import "Path" "react-konva"
