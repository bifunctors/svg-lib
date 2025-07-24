namespace SvgLib;

public static class SvgColour {
    public static readonly string NONE   = "none";
    public static readonly string BLACK  = "black";
    public static readonly string WHITE  = "white";
    public static readonly string GRAY   = "gray";

    public static readonly string[] Colours = new[] {
        "#FFB3BA", // pastel pink
        "#BAE1FF", // pastel blue
        "#BAFFC9", // pastel mint
        "#FFDAC1", // pastel peach
        "#CBAACB", // pastel purple
        "#AFF8DB", // pastel turquoise
        "#FDFD96"  // pastel yellow
    };

    private static int Seed = new Random().Next();

    public static string RandomColour(int num) {
        return Colours[new Random(num + Seed).Next(0, Colours.Length)];
    }
}
