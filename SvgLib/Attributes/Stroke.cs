namespace SvgLib;

public interface Stroke<T> where T : Stroke<T> {
    public string StrokeColour { get; set; }

    public T Border(string colour) {
        StrokeColour = colour;
        return (T)this;
    }
}

