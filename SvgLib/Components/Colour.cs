using System.Xml.Serialization;

namespace SvgLib;

public interface Colour {
    [XmlAttribute("fill")]
    public string Fill { get; set; }
}
