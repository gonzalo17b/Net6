namespace Novedades.csharp7;

public class LocalFunctions
{
    public enum Operation
    {
        Sum,
        Multiply,
    }

    public static int DoStuff(Operation operation, int a, int b)
    {
        switch (operation)
        {
            case Operation.Sum: return Sum(a, b);
            case Operation.Multiply: return Multiply(a, b);
            default: throw new ArgumentOutOfRangeException(nameof(operation));
        }

        int Sum(int a, int b)
        {
            return a + b;
        }

        int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}


