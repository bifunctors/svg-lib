using System.Xml.Serialization;

namespace SvgLib;

public interface Shape {
    [XmlAttribute("x")]
    public int X { get; set; }
    [XmlAttribute("y")]
    public int Y { get; set; }
}
