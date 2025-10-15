namespace Feliz.Skia

open Fable.Core
open Fable.Core.JsInterop

[<Erase; RequireQualifiedAccess>]
module Interop =
    let inline mkSkiaProp (key: string) (value: obj) : ISkiaProp = unbox (key, value)
    let inline mkCanvasProp (key: string) (value: obj) : ICanvasProp = unbox (key, value)
    let inline mkRectProp (key: string) (value: obj) : IRectProp = unbox (key, value)
    let inline mkCircleProp (key: string) (value: obj) : ICircleProp = unbox (key, value)
    let inline mkStylesProp (key: string) (value: obj) : ISkiaStylesProp = unbox (key, value)
    let inline mkOptionsProp (key: string) (value: obj) : IOptionsProp = unbox (key, value)

    let skia: obj = importAll "@shopify/react-native-skia/lib/module/web"

    let canvas: obj = import "Canvas" "@shopify/react-native-skia/lib/module"
    let circle: obj = import "Circle" "@shopify/react-native-skia/lib/module"
    let rect:   obj = import "Rect"   "@shopify/react-native-skia/lib/module"
    skia?LoadSkiaWeb()
