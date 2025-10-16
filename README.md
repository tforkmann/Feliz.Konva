# Feliz Binding for [react-konva](https://konvajs.org/docs/react/index.html)

[![Feliz.Konva on Nuget](https://buildstats.info/nuget/Feliz.Konva)](https://www.nuget.org/packages/Feliz.Konva/)
[![Docs](https://github.com/tforkmann/Feliz.Konva/actions/workflows/Docs.yml/badge.svg)](https://github.com/tforkmann/Feliz.Konva/actions/workflows/Docs.yml)

## Installation
Install the nuget package
```
dotnet paket add Feliz.Konva
```

and install the npm package

```
npm install --save react-konva
```

or use Femto:
```
femto install Feliz.Konva
```

## Start test app

- Start your test app by cloning this repository and then execute:
```
dotnet run
```

## Example Feliz.Konva usage
Here is an example Feliz.Konva
```fs
[<ReactComponent>]
let Konva () =
    Html.div [
        prop.style [ style.height 500; style.width 500 ]
        prop.children [
            Konva.stage [
                stage.width 500
                stage.height 500
                stage.children [
                    Konva.layer [
                        layer.children [
                            Konva.circle [
                                circle.x 200
                                circle.y 200
                                circle.radius 70
                                circle.fill "red"
                                circle.stroke "black"
                                circle.strokeWidth 4
                            ]
                            Konva.text [
                                text.x 150
                                text.y 180
                                text.text "Hello, Konva!"
                                text.fontSize 30
                                text.fontFamily "Calibri"
                                text.fill "green"
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]
```

You can find more examples [here](https://tforkmann.github.io/Feliz.Konva/)
