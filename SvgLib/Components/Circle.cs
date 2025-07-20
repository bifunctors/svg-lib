using System.Xml.Serialization;

namespace SvgLib;

public interface Circular : Shape {
    [XmlAttribute("cx")]
    new public int X { get; set; }
    [XmlAttribute("cy")]
    new public int Y { get; set; }
    [XmlAttribute("r")]
    public int Radius { get; set; }
}


public class Circle : Circular, Colour {
    [XmlAttribute("cx")]
    public int X { get; set; }
    [XmlAttribute("cy")]
    public int Y { get; set; }

    [XmlAttribute("r")]
    public int Radius { get; set; }

    [XmlAttribute("fill")]
    public string Fill { get; set; } = String.Empty;

    [XmlAttribute("stroke")]
    public string Stroke { get; set; } = String.Empty;
}
