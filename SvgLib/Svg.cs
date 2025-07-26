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
            Rects = OrderByLayer<Rectangle>(Shapes),
            Circles = OrderByLayer<Circle>(Shapes),
            Texts = OrderByLayer<Text>(Shapes),
            Lines = OrderByLayer<Line>(Shapes)
        };

        serializer.Serialize(stream, svg_serializer);
    }

    private static List<T> OrderByLayer<T>(List<Shape> list) where T : Shape, Layer =>
        list.Where(x => x is T).Cast<T>().OrderBy(x => x.GroupingLayer).ToList();
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
