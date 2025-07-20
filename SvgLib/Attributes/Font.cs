namespace SvgLib;

public interface Font<T> where T : Font<T> {
    public float FontSize { get; set; }
    public string FontFamily { get; set; }
    public string DominantBaseline { get; set; }
    public string TextAnchor { get; set; }
    public string String { get; set; }

    public T Family(string family) {
        FontFamily = family;
        return (T)this;
    }
}
