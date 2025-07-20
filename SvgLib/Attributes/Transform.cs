namespace SvgLib;

public interface Transform<T> where T : Transform<T> {
    protected int X { get; set; }
    protected int Y { get; set; }

    public T Position(int x, int y) {
        X = x;
        Y = y;
        return (T)this;
    }

    public T Size(int x, int y);
}
