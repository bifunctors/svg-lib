namespace SvgLib;

public interface Colour<T> where T : Colour<T> {
    public string Fill { get; set; }

    public T Background(string colour) {
        Fill = colour;
        return (T)this;
    }
}
