namespace Feliz.Konva

open Feliz
open Fable.Core.JsInterop
open Fable.Core

type Event = Browser.Types.Event

[<Erase>]
type Konva =

    static member inline stage(props: IStageProp seq) =
        Interop.reactApi.createElement (Interop.stage, createObj !!props)
    static member inline children(children: ReactElement list) =
        unbox<IKonvaProp> (prop.children children)

    static member inline layer(props: ILayerProp seq) =
        Interop.reactApi.createElement (Interop.layer, createObj !!props)
    static member inline rect(props: IRectProp seq) =
        Interop.reactApi.createElement (Interop.rect, createObj !!props)

    static member inline circle(props: ICircleProp seq) =
        Interop.reactApi.createElement (Interop.circle, createObj !!props)
    static member inline text(props: ITextProp seq) =
        Interop.reactApi.createElement (Interop.text, createObj !!props)
    static member inline image(props: IImageProp seq) =
        Interop.reactApi.createElement (Interop.image, createObj !!props)
    static member inline path(props: IPathProp seq) =
        Interop.reactApi.createElement (Interop.path, createObj !!props)
    static member inline createTween(props: ITweenProp seq) : ITween =
        let konva: obj = importDefault "konva"
        let ctor =
            if not (isNullOrUndefined (konva?Tween)) then konva?Tween
            else konva?``default``?Tween
        createNew ctor (createObj !!props) |> unbox<ITween>

    static member inline key(key: string) : IKonvaProp = Interop.mkKonvaProp "key" key

    static member inline option props : IOptionsProp = !!(createObj !!props)

    static member inline plugins(props: obj seq) = !!("plugins" ==> props)

