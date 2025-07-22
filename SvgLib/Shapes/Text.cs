using System.Xml.Serialization;

namespace SvgLib;

public class Text : Shape, Transform<Text>, Fill<Text>, Font<Text> {
    [XmlAttribute("x")]
    public int X { get; set; }
    [XmlAttribute("y")]
    public int Y { get; set; }

    [XmlAttribute("font-family")]
    public string FontFamily { get; set; } = "JetBrains Mono";
    [XmlAttribute("font-size")]
    public float FontSize { get; set; }

    [XmlAttribute("fill")]
    public string FillColour { get; set; } = String.Empty;

    [XmlAttribute("dominant-baseline")]
    public string DominantBaseline { get; set; } = "hanging";

    [XmlAttribute("text-anchor")]
    public string TextAnchor { get; set; } = "start";

    [XmlText]
    public string String { get; set; } = "";

    public Text Position(int x, int y) {
        X = x;
        Y = y;
        return this;
    }

    public Text Size(int x, int _) {
        FontSize = x;
        return this;
    }

    public Text Background(string colour) {
        FillColour = colour;
        return this;
    }

    public Text Content(string content) {
        String = content;
        return this;
    }
}
