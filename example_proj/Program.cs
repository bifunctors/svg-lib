using System;
using SvgLib;

Console.WriteLine("Serializing SVG");

var svg = new SvgLib.Svg();

Shape[] shapes = [
    new Rectangle()
        .Position(10, 10)
        .Size(50, 50)
        .Background("black")
        .Border("none"),

    new Rectangle()
        .Position(10, 300)
        .Size(50, 50)
        .Background("orange")
        .Border("none"),

    new Circle()
        .Size(50)
        .Position(800, 500)
        .Background("blue"),

    new Circle()
        .Size(100)
        .Position(200, 250)
        .Background("purple"),

    new Text()
        .Size(100)
        .Background("green")
        .Position(100, 100)
        .Font("Arial")
        .Content("Hello, World!")
];


svg.Shapes.AddRange(shapes);

svg.Serialize("Resources/example.svg");

Console.WriteLine("Serialized");
