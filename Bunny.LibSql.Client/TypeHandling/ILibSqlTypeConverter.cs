public interface ILibSqlTypeConverter<T> : ILibSqlTypeConverter
{
    string Serialise(T obj);
    T Deserialise(string str);

    string ILibSqlTypeConverter.Serialise(object? obj)
    {
        if (obj is T t)
            return Serialise(t);

        throw new Exception("Cannot serialise " + typeof(T).FullName);
    }

    object? ILibSqlTypeConverter.Deserialise(string? str)
    {
        return str is null ? null : Deserialise(str);
    }
}

public interface ILibSqlTypeConverter
{
    string Serialise(object? obj);
    object? Deserialise(string? value);
}