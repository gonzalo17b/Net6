namespace Novedades.csharp8;

using System.Diagnostics.CodeAnalysis;

public class NullableReferenceTypes
{
    public string? NullableString { get; set; }
    public string NonNullableString { get; set; }

    public NullableReferenceTypes()
    {
        NonNullableString = "Valor";
    }

    public NullableReferenceTypes(string? nullableString)
    {
        NullableString = nullableString;
        NonNullableString = nullableString ?? "Valor";
    }

    [return: MaybeNull]
    public string FunctionWithReturnvalue()
    {
        return NullableString;
    }

    public bool FunctionWithOutputvalue([MaybeNullWhen(returnValue: false)] out string value)
    {
        value = NullableString;
        return NullableString != null;
    }
}