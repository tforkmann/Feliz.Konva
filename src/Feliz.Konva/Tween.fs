namespace Feliz.Konva

open Feliz
open Fable.Core.JsInterop
open Fable.Core

[<Erase>]
type tween =

    static member inline key(key: string) : ITweenProp = Interop.mkTweenProp "key" key

    static member inline children(children: ReactElement list) =
        unbox<ITweenProp> (prop.children children)

    static member inline onFinish(callback: unit -> unit) : ITweenProp = Interop.mkTweenProp "onFinish" callback
    static member inline onUpdate(callback: unit -> unit) : ITweenProp = Interop.mkTweenProp "onUpdate" callback
    static member inline duration(duration: float) : ITweenProp = Interop.mkTweenProp "duration" duration
    static member inline easing
        (handler: float -> float)
        : ITweenProp =
        !!("easing" ==> handler)
    static member inline opacity(opacity: float) : ITweenProp = Interop.mkTweenProp "opacity" opacity
    static member inline strokeWidth(strokeWidth: float) : ITweenProp = Interop.mkTweenProp "strokeWidth" strokeWidth
    static member inline delay(delay: float) : ITweenProp = Interop.mkTweenProp "delay" delay
    static member inline repeat(repeat: int) : ITweenProp = Interop.mkTweenProp "repeat" repeat
    static member inline yoyo(yoyo: bool) : ITweenProp = Interop.mkTweenProp "yoyo" yoyo
    static member inline offset(offset: float) : ITweenProp = Interop.mkTweenProp "offset" offset
    static member inline autoplay(autoplay: bool) : ITweenProp = Interop.mkTweenProp "autoplay" autoplay
    static member inline paused(paused: bool) : ITweenProp = Interop.mkTweenProp "paused" paused
    static member inline reversed(reversed: bool) : ITweenProp = Interop.mkTweenProp "reversed" reversed
    static member inline node(node: obj) : ITweenProp = Interop.mkTweenProp "node" node
    static member inline finish() : ITweenProp = Interop.mkTweenProp "finish" ()
    static member inline reset() : ITweenProp = Interop.mkTweenProp "reset" ()
    static member inline play() : ITweenProp = Interop.mkTweenProp "play" ()
    static member inline pause() : ITweenProp = Interop.mkTweenProp "pause" ()
    static member inline reverse() : ITweenProp = Interop.mkTweenProp "reverse" ()
    static member inline destroy() : ITweenProp = Interop.mkTweenProp "destroy" ()
