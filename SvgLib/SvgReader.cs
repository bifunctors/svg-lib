using System.Xml;

namespace SvgLib;

public class SvgReader {
    public string Read(string? path) {
        if (path is null) path = "Resources/example.svg";

        var doc = new XmlDocument();
        doc.Load(path!);

        var root = doc.DocumentElement;
        Console.WriteLine($"Loaded DocumentRoot: {root!.Name}");

        foreach(XmlAttribute attr in root.Attributes) {
            Console.WriteLine($"{attr.Name} = {attr.Value}");
        }

        var rects = doc.GetElementsByTagName("rect");

        Console.WriteLine($"Found {rects.Count} path elements");

        foreach(XmlElement e in rects) {
            foreach(XmlAttribute attr in e.Attributes) {
                Console.WriteLine($"{attr.Name} = {attr.Value}");
            }
        }

        return "";
    }
}
