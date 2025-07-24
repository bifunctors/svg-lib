using System.Xml;
using System.Xml.Serialization;

namespace SvgLib;

public class Svg {
    public int Width { get; set; }
    public int Height { get; set; }

    public List<Shape> Shapes { get; set; } = new();

    private const int DEFAULT_SIZE = 1000;

    public Svg() {
        Width = DEFAULT_SIZE;
        Height = DEFAULT_SIZE;
    }

    public Svg(int width, int height) {
        Width = width;
        Height = height;
    }

    public void Serialize(string path) {
        if (path == String.Empty) path = "Resources/example.svg";

        var serializer = new XmlSerializer(typeof(SvgSerializer));
        using var stream = new FileStream(path, FileMode.Create);

        var svg_serializer = new SvgSerializer {
            Width = this.Width,
            Height = this.Height,
            Rects = this.Shapes
                .Where(x => x is Rectangle)
                .Select(x => (Rectangle)x)
                .OrderBy(x => x.GroupingLayer)
                .ToList(),
            Circles = this.Shapes
                .Where(x => x is Circle)
                .Select(x => (Circle)x)
                .OrderBy(x => x.GroupingLayer)
                .ToList(),
            Texts = this.Shapes
                .Where(x => x is Text)
                .Select(x => (Text)x)
                .OrderBy(x => x.GroupingLayer)
                .ToList(),
            Lines = this.Shapes
                .Where(x => x is Line)
                .Select(x => (Line)x)
                .OrderBy(x => x.GroupingLayer)
                .ToList(),
        };

        serializer.Serialize(stream, svg_serializer);
    }
}

[XmlRoot(ElementName = "svg",
         Namespace = "http://www.w3.org/2000/svg")]
public class SvgSerializer {
    [XmlAttribute("width")]
    public required int Width { get; set; }

    [XmlAttribute("height")]
    public required int Height { get; set; }

    [XmlElement("circle")]
    public required List<Circle> Circles { get; set; } = new();

    [XmlElement("line")]
    public required List<Line> Lines { get; set; } = new();

    [XmlElement("rect")]
    public required List<Rectangle> Rects { get; set; } = new();

    [XmlElement("text")]
    public required List<Text> Texts { get; set; } = new();
}
