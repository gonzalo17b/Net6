namespace Novedades.csharp7;

public class PatternMatching
{
    public static void DoStuff(object obj)
    {
        if (obj is null) // is expression
        {
            throw new ArgumentNullException(nameof(obj));
        }

        if (!(obj is string strValue)) // is expression with assignment
        {
            throw new ArgumentException("Invalid value", nameof(obj));
        }
    }
}


