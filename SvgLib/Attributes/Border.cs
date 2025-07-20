namespace SvgLib;

public interface Stroke<T> where T : Stroke<T> {
    public string Colour { get; set; }

    public T Border(string colour) {
        Colour = colour;
        return (T)this;
    }
}

