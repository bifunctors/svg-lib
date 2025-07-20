using System.Xml.Serialization;

namespace SvgLib;

public class Circle : Shape, Transform<Circle>, Colour<Circle>, Stroke<Circle> {
    [XmlAttribute("cx")]
    public int X { get; set; }
    [XmlAttribute("cy")]
    public int Y { get; set; }

    [XmlAttribute("r")]
    public int Radius { get; set; }

    [XmlAttribute("fill")]
    public string Fill { get; set; } = String.Empty;

    [XmlAttribute("stroke")]
    public string Colour { get; set; } = String.Empty;

    public Circle Position(int x, int y) {
        X = x;
        Y = y;
        return this;
    }

    public Circle Size(int x, int _) {
        Radius = x;
        return this;
    }

    public Circle Background(string colour) {
        Colour = colour;
        return this;
    }
}
