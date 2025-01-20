namespace Enumerators;

public static class Enumerator {
    public static T? MyFirstOrDefault<T>(this IEnumerable<T> coll) {
        var it = coll.GetEnumerator();

        if(!it.MoveNext())
            return default;
        
        return it.Current;
    }

     public static T? MyLastOrDefault<T>(this IEnumerable<T> coll) {
        var it = coll.GetEnumerator();
        T? last = default;

        while(it.MoveNext())
            last = it.Current;

        return last;
    }

    public static T[] MyToArray<T>(this IEnumerable<T> coll) {
        var it = coll.GetEnumerator();

        T[] array = new T[coll.MyCount()];

        it.MoveNext();

        for (int i = 0; i < coll.MyCount(); i++) {
            array[i] = it.Current;
            it.MoveNext();
        }

        return array;
    }

    public static List<T> MyToList<T>(this IEnumerable<T> coll) {
        List<T> list = [.. coll];
        
        return list;
    }

    public static IEnumerable<T> MyTake<T>(this IEnumerable<T> coll, int num) {
        var it = coll.GetEnumerator();

        for (int i = 0; i < num; i++) {
            it.MoveNext();
            yield return it.Current;
        }
    }

    public static IEnumerable<T> MySkip<T>(this IEnumerable<T> coll, int num) {
        var it = coll.GetEnumerator();

        for (int i = 0; i < num; i++) {
            it.MoveNext();
        }

        for (int i = num; i < coll.MyCount(); i++) {
            it.MoveNext();
            yield return it.Current;
        }
    }

    public static IEnumerable<T> MyAppend<T>(this IEnumerable<T> coll, T item) {
        var it = coll.GetEnumerator();

        while(it.MoveNext())
            yield return it.Current;
        
        yield return item;
    }

    public static IEnumerable<T> MyPreprend<T>(this IEnumerable<T> coll, T item) {
        var it = coll.GetEnumerator();

        yield return item;

        while(it.MoveNext())
            yield return it.Current;
    }

    public static int MyCount<T>(this IEnumerable<T> coll) {
        var it = coll.GetEnumerator();
        
        var count = 0;

        while(it.MoveNext())
            count++;

        return count;
    }

    public static IEnumerable<T> MyWhere<T> (this IEnumerable<T> coll, Func<T, bool> predicate) {
        foreach (var item in coll){
            if (predicate(item))
                yield return item;  
        }
    }

    public static IEnumerable<R> MySelect<T, R> (this IEnumerable<T> coll, Func<T, R> map) {
        var it = coll.GetEnumerator();

        while(it.MoveNext())
            yield return map(it.Current);
    }
}