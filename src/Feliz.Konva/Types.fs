namespace Feliz.Konva

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
