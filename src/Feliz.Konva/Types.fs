namespace Feliz.Konva

open Fable.Core

type IKonvaProp =
    interface
    end

type IStageProp =
    interface
    end
type ILayerProp =
    interface
    end

type IRectProp =
    interface
    end

type ICircleProp =
    interface
    end
type ITextProp =
    interface
    end
type IImageProp =
    interface
    end
type IPathProp =
    interface
    end
type ITweenProp =
    interface
    end

type IKonvaStylesProp =
    interface
    end

type IOptionsProp =
    interface
    end

[<RequireQualifiedAccess>]
type DateOption =
| Date of System.DateTime
| DateTimeOffset of System.DateTimeOffset
| String of string
| Number of float
    member this.Value =
        match this with
        | Date d -> d :> obj
        | DateTimeOffset dto -> dto :> obj
        | String s -> s :> obj
        | Number n -> n :> obj

[<Erase>]
type ITween =
    abstract member play: unit -> unit
    abstract member reverse: unit -> unit
    abstract member pause: unit -> unit
    abstract member finish: unit -> unit
    abstract member destroy: unit -> unit
