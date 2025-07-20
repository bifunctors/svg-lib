using static SvgLib.SvgColour;
using SvgLib;

Console.WriteLine("Serializing SVG");

var svg = new SvgLib.Svg(500, 500);

List<Shape> shapes = [];

Enumerable.Range(0, 8)
    .SelectMany(row =>
        Enumerable.Range(0, 8)
            .Select(col =>
                new TextBox(col * 48, row * 40, $"{(char)('A' + col)}{8 - row}")
                    .Background((row + col) % 2 == 0 ? WHITE : BLACK)
                    .Foreground((row + col) % 2 == 0 ? BLACK : WHITE)
                    .Rounded(false)
            )
    )
    .Select(tb => tb.Shapes())
    .ToList()
    .ForEach(shapes.AddRange);

svg.Shapes.AddRange(shapes);

svg.Serialize("Resources/example.svg");

Console.WriteLine("Serialized");
