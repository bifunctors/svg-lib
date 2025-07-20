using static SvgLib.SvgColour;
using System;
using SvgLib;

Console.WriteLine("Serializing SVG");

var svg = new SvgLib.Svg();

var a = new Rectangle();
a.Size(10, 10);

svg.Shapes.AddRange([
    new Rectangle()
        .Position(50, 50)
        .Size(100, 20)
        .Background(BLACK)
]);

svg.Serialize("Resources/example.svg");

Console.WriteLine("Serialized");
