public interface IEnumerator<T> {
    bool MoveNext();
    T Current { get; }
}

public interface IEnumerable<T> {
    IEnumerator<T> GetEnumerator();
}