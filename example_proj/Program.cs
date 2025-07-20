using static SvgLib.SvgColour;
using System;
using SvgLib;

Console.WriteLine("Serializing SVG");

var svg = new SvgLib.Svg();

svg.Shapes.AddRange([
    new Rectangle()
        .Position(50, 50)
        .Size(100, 20)
        .Background(BLACK),

    new Line()
        .Position(10, 10)
        .Size(100, 10)
        .Border(BLACK),
]);

svg.Serialize("Resources/example.svg");

Console.WriteLine("Serialized");
