using System.Xml.Serialization;

namespace SvgLib;

public class Line : Shape, Transform<Line>, Stroke<Line> {
    [XmlAttribute("x1")]
    public int X { get; set; }
    [XmlAttribute("y1")]
    public int Y { get; set; }
    [XmlAttribute("x2")]
    public int EndX { get; set; }
    [XmlAttribute("y2")]
    public int EndY { get; set; }

    [XmlAttribute("stroke")]
    public string StrokeColour { get; set; } = String.Empty;

    public Line Position(int x, int y) {
        X = x;
        Y = y;
        return this;
    }

    public Line Size(int x, int y) {
        EndX = x;
        EndY = y;
        return this;
    }

    public Line Border(string colour) {
        StrokeColour = colour;
        return this;
    }
}
