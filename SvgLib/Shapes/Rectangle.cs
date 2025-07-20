using System.Xml.Serialization;

namespace SvgLib;

public class Rectangle : Shape, Transform<Rectangle>, Colour<Rectangle>, Stroke<Rectangle> {
    [XmlAttribute("x")]
    public int X { get; set; }
    [XmlAttribute("y")]
    public int Y { get; set; }

    [XmlAttribute("width")]
    public int Width { get; set; }
    [XmlAttribute("height")]
    public int Height { get; set; }

    [XmlAttribute("fill")]
    public string Fill { get; set; } = String.Empty;

    [XmlAttribute("stroke")]
    public string Colour { get; set; } = String.Empty;

    public Rectangle Position(int x, int y) {
        X = x;
        Y = y;
        return this;
    }

    public Rectangle Size(int x, int y) {
        Width = x;
        Height = y;
        return this;
    }

    public Rectangle Background(string colour) {
        Colour = colour;
        return this;
    }
}
