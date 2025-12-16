namespace Feliz.Konva

open Feliz
open Fable.Core.JsInterop
open Fable.Core

type Event = Browser.Types.Event

[<Erase>]
type Konva =

    static member inline stage(props: IStageProp seq) =
        ReactLegacy.createElement (Interop.Stage, createObj !!props)
    static member inline children(children: ReactElement list) =
        unbox<IKonvaProp> (prop.children children)

    static member inline layer(props: ILayerProp seq) =
        ReactLegacy.createElement (Interop.Layer, createObj !!props)
    static member inline rect(props: IRectProp seq) =
        ReactLegacy.createElement (Interop.Rect, createObj !!props)

    static member inline circle(props: ICircleProp seq) =
        ReactLegacy.createElement (Interop.Circle, createObj !!props)
    static member inline text(props: ITextProp seq) =
        ReactLegacy.createElement (Interop.Text, createObj !!props)
    static member inline image(props: IImageProp seq) =
        ReactLegacy.createElement (Interop.Image, createObj !!props)
    static member inline path(props: IPathProp seq) =
        ReactLegacy.createElement (Interop.Path, createObj !!props)
    static member inline createTween(props: ITweenProp seq) : ITween =
        let konva: obj = importDefault "konva"
        let ctor =
            if not (isNullOrUndefined (konva?Tween)) then konva?Tween
            else konva?``default``?Tween
        createNew ctor (createObj !!props) |> unbox<ITween>

    static member inline key(key: string) : IKonvaProp = Interop.mkKonvaProp "key" key

    static member inline option props : IOptionsProp = !!(createObj !!props)

    static member inline plugins(props: obj seq) = !!("plugins" ==> props)

