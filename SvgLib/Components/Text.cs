using System.Xml.Serialization;

namespace SvgLib;

public class Text : Shape, Colour, Font {
    [XmlAttribute("x")]
    public int X { get; set; }
    [XmlAttribute("y")]
    public int Y { get; set; }

    [XmlAttribute("font-family")]
    public string Family { get; set; } = "Arial";

    [XmlAttribute("font-size")]
    public float Size { get; set; }

    [XmlAttribute("fill")]
    public string Fill { get; set; } = String.Empty;
}
