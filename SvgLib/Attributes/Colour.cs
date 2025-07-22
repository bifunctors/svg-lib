namespace SvgLib;

public interface Fill<T> where T : Fill<T> {
    public string FillColour { get; set; }

    public T Colour(string colour) {
        FillColour = colour;
        return (T)this;
    }
}
