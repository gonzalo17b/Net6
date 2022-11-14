namespace Novedades.csharp7;

public class ThrowExpressions
{
    public string Value { get; }

    public ThrowExpressions(string? value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }
}


