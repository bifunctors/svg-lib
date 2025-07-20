using System.Xml.Serialization;

namespace SvgLib;

public interface Font {
    [XmlAttribute("font-family")]
    public string Family { get; set; }

    [XmlAttribute("font-size")]
    public float Size { get; set; }
}
