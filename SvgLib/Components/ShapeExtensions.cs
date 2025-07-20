namespace SvgLib;

public static class ShapeExtensions {
    public static T Position<T>(this T shape, int x, int y) where T : Shape {
        shape.X = x;
        shape.Y = y;

        return shape;
    }

    public static T Size<T>(this T rect, int width, int height) where T : Rectangular {
        rect.Width = width;
        rect.Height = height;

        return rect;
    }

    public static T Size<T>(this T circle, int width) where T : Circular {
        circle.Radius = width;
        return circle;
    }

    public static T Size<T>(this T text, float size) where T : Font {
        text.Size = size;
        return text;
    }

    public static T Background<T>(this T shape, string fill) where T : Colour {
        shape.Fill = fill;
        return shape;
    }

    public static T Border<T>(this T shape, string stroke) where T : Border {
        shape.Stroke = stroke;
        return shape;
    }

    public static T Font<T>(this T text, string font) where T : Font {
        text.Family = font;
        return text;
    }

    public static T Content<T>(this T text, string content) where T : Text {
        text.Family = content;
        return text;
    }
}
