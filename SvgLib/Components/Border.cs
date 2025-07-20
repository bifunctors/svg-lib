using System.Xml.Serialization;

namespace SvgLib;

public interface Border {
    [XmlAttribute("stroke")]
    public string Stroke { get; set; }
}

