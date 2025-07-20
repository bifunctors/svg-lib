using System.Xml.Serialization;

namespace SvgLib;

public interface Rectangular : Shape {
    [XmlAttribute("width")]
    public int Width { get; set; }
    [XmlAttribute("height")]
    public int Height { get; set; }
}

public class Rectangle : Rectangular, Colour, Border {
    [XmlAttribute("width")]
    public int Width { get; set; }
    [XmlAttribute("height")]
    public int Height { get; set; }

    [XmlAttribute("x")]
    public int X { get; set; }
    [XmlAttribute("y")]
    public int Y { get; set; }

    [XmlAttribute("fill")]
    public string Fill { get; set; } = String.Empty;

    [XmlAttribute("stroke")]
    public string Stroke { get; set; } = String.Empty;
}
