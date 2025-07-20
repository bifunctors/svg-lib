using System.Xml.Serialization;

namespace SvgLib;

public class Text : Shape, Transform<Text>, Colour<Text>, Font<Text> {
    [XmlAttribute("x")]
    public int X { get; set; }
    [XmlAttribute("y")]
    public int Y { get; set; }

    [XmlAttribute("font-family")]
    public string FontFamily { get; set; } = "Arial";
    [XmlAttribute("font-size")]
    public float FontSize { get; set; }

    [XmlAttribute("fill")]
    public string Fill { get; set; } = String.Empty;

    [XmlAttribute("dominant-baseline")]
    public string DominantBaseline { get; set; } = "hanging";

    [XmlAttribute("text-anchor")]
    public string TextAnchor { get; set; } = "start";

    [XmlText]
    public string String { get; set; } = "";

    public Text Size(int x, int _) {
        FontSize = x;
        return this;
    }
}
