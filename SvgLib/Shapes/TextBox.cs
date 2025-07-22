using static SvgLib.SvgColour;

namespace SvgLib;

public class TextBox {
    private readonly Rectangle rectangle;
    private readonly Text text;
    private readonly int x_padding = 0;
    private readonly int y_padding = 6;

    private static int DEFAULT_WIDTH_PER_CHAR = 24;
    private static int DEFAULT_HEIGHT = 40;
    private static int DEFAULT_FONT_SIZE = 40;

    public TextBox(int x, int y, int width, int height, string content) {
        rectangle = new Rectangle()
            .Position(x, y)
            .Size(width, height)
            .Background(WHITE)
            .Border(BLACK);
        text = new Text()
            .Position(x + x_padding, y + y_padding)
            .Size(DEFAULT_FONT_SIZE, -1)
            .Background(BLACK)
            .Content(content);
    }

    public TextBox(int x, int y, string content) {
        rectangle = new Rectangle()
            .Position(x, y)
            .Size(DEFAULT_WIDTH_PER_CHAR * content.Length, DEFAULT_HEIGHT)
            .Background("white")
            .Border("black");
        text = new Text()
            .Position(x + x_padding, y + y_padding)
            .Size(DEFAULT_FONT_SIZE, -1)
            .Background("black")
            .Content(content);
    }

    public TextBox Background(string colour) {
        this.rectangle.Background(colour);
        return this;
    }

    public TextBox Foreground(string colour) {
        this.text.Background(colour);
        return this;
    }

    public TextBox Border(string colour) {
        this.rectangle.Border(colour);
        return this;
    }

    public TextBox Rounded(bool is_rounded) {
        rectangle.Rounded(is_rounded);
        return this;
    }

    public IEnumerable<Shape> Shapes() {
        return [rectangle, text];
    }
}
