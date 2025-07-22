using System.Xml;
using System.Xml.Serialization;

namespace SvgLib;

public class Ellipse : Shape, Transform<Ellipse>, Fill<Ellipse>, Stroke<Ellipse> {
    [XmlAttribute("cx")]
    public int X { get; set; }
    [XmlAttribute("cy")]
    public int Y { get; set; }

    [XmlAttribute("rx")]
    public int RX { get; set; }
    [XmlAttribute("ry")]
    public int RY { get; set; }

    [XmlAttribute("fill")]
    public string FillColour { get; set; } = String.Empty;

    [XmlAttribute("stroke")]
    public string StrokeColour { get; set; } = String.Empty;

    public Ellipse Position(int x, int y) {
        X = x;
        Y = y;
        return this;
    }

    public Ellipse Size(int x, int y) {
        RX = x;
        RY = y;
        return this;
    }

    public Ellipse Colour(string colour) {
        FillColour = colour;
        return this;
    }

    public Ellipse Border(string colour) {
        StrokeColour = colour;
        return this;
    }
}
