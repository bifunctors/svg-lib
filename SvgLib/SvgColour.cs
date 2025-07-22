namespace SvgLib;

public static class SvgColour {
    public static readonly string NONE = "none";
    public static readonly string BLACK = "black";
    public static readonly string WHITE = "white";
    public static readonly string GRAY = "gray";
    public static readonly string GREEN = "green";
    public static readonly string BLUE = "blue";
    public static readonly string RED = "red";
    public static readonly string ORANGE = "orange";
    public static readonly string PURPLE = "purple";

    public static readonly string[] Colours = [
        GREEN!, BLUE!, RED!, ORANGE!, PURPLE!, "coral", "cornflowerblue",
        "crimson", "dodgerblue", "darkmagenta", "hotpink", "greenyellow",
        "mediumpurple", "lightsteelblue", "indigo", "goldenrod", "teal",
        "tomato", "turquoise", "peachpuff", "lightsalmon", "darkorchid",
        "darkcyan", "cyan", "deeppink", "magenta", "maroon"
    ];

    private static int Seed = new Random().Next();

    public static string RandomColour(int num) {
        return Colours[new Random(num + Seed).Next(0, Colours.Length)];
    }
}
