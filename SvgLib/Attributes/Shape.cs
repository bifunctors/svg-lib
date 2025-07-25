namespace SvgLib;
public interface Shape;

public interface Layer {
    public int GroupingLayer { get; set; }
}

public static class ShapeExtension {
    public static void AddTo(this IEnumerable<Shape> @this, List<Shape> shapes) {
        shapes.AddRange(@this);
    }
}
