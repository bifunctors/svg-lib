using System.Xml.Serialization;

namespace SvgLib;

public class Circle : Shape, Layer, Transform<Circle>, Fill<Circle>, Stroke<Circle> {
    [XmlAttribute("cx")]
    public int X { get; set; }
    [XmlAttribute("cy")]
    public int Y { get; set; }

    [XmlAttribute("r")]
    public int Radius { get; set; }

    [XmlAttribute("fill")]
    public string FillColour { get; set; } = String.Empty;

    [XmlAttribute("stroke")]
    public string StrokeColour { get; set; } = String.Empty;

    public int GroupingLayer { get; set; } = 0;

    public Circle Position(int x, int y) {
        X = x;
        Y = y;
        return this;
    }

    public Circle Size(int x, int _) {
        Radius = x;
        return this;
    }

    public Circle Colour(string colour) {
        StrokeColour = colour;
        return this;
    }
    public Circle Layer(int num) {
        GroupingLayer = num;
        return this;
    }
}
