using System.Xml.Serialization;

namespace SvgLib;

public class Rectangle : Shape, Transform<Rectangle>, Fill<Rectangle>, Stroke<Rectangle> {
    [XmlAttribute("x")]
    public int X { get; set; } = 0;
    [XmlAttribute("y")]
    public int Y { get; set; } = 0;

    [XmlAttribute("rx")]
    public int Rx { get; set; } = 0;
    [XmlAttribute("ry")]
    public int Ry { get; set; } = 0;

    [XmlAttribute("width")]
    public int Width { get; set; } = 0;
    [XmlAttribute("height")]
    public int Height { get; set; } = 0;

    [XmlAttribute("fill")]
    public string FillColour { get; set; } = String.Empty;

    [XmlAttribute("stroke")]
    public string StrokeColour { get; set; } = String.Empty;

    private static int DEFAULT_CORNER_RADII = 6;

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
        FillColour = colour;
        return this;
    }

    public Rectangle Border(string colour) {
        StrokeColour = colour;
        return this;
    }

    public Rectangle Rounded(bool is_rounded) {
        int radius = is_rounded ? DEFAULT_CORNER_RADII : 0;
        Rx = radius;
        Ry = radius;
        return this;
    }

    public Rectangle Rounded(int radius) {
        Rx = radius;
        Ry = radius;
        return this;
    }
}
