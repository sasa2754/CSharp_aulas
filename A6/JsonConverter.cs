using System.Collections;
using System.Reflection;
using System.Text;

public static class Converter {

    // O usuário manda um objeto de alguma classe tipo Pessoa
    public static string ToJson<T>(this T obj) {
        var sb = new StringBuilder();

        toJson(obj, sb);
        return sb.ToString();
    }

    private static void toJson<T>(this T obj, StringBuilder sb) {
        var type = obj?.GetType();

        if (obj is IEnumerable collection && !(obj is string)) {

            sb.Append("[\n");
            bool isFirst = true;

            foreach (var item in collection) {
                if (!isFirst)
                    sb.Append(",\n");

                if (item is string or char)
                    sb.Append($"\t\"{item}\"");

                else if (item is int || item is float || item is double || item is bool || item is decimal || item is byte || item is short || item is long)
                    sb.Append($"{item.ToString()?.ToLower()}");

                else
                    toJson(item, sb);

                isFirst = false;
            }

            sb.Append("\n\t]");
            return;
        }

        var properties = type?.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            ?.Where(p => p.GetIndexParameters().Length == 0)
            .ToArray();

        sb.Append("{\n\n");

        for (int i = 0; i < properties?.Length; i++) {
            var property = properties[i];
            var name = property.Name;
            var value = property.GetValue(obj);

            sb.Append($"\"{name}\": ");

            if (value is null)
                sb.Append("null");

            else if (value is string or char)
                sb.Append($"\"{value}\"");

            else if (value is int || value is float || value is double || value is bool || value is decimal || value is byte || value is short || value is long)
                sb.Append($"{value?.ToString()?.ToLower()}");

            else
                toJson(value, sb);

            if(i < properties.Length -1)
                sb.Append(",\n");
                
        }

        sb.Append("\n}");

    }
}