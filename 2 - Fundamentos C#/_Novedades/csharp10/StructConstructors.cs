namespace Novedades.csharp10;

internal static class StructConstructors
{
    public static void DoStuff()
    {
        var data = new Data();
        Console.WriteLine(data.ToString()); // Prints "1"

        data = default;
        Console.WriteLine(data); // Prints "0", cuidado, no pasa validaciones!

        data = (new Data[10])[0];
        Console.WriteLine(data); // Prints "0", cuidado, no pasa validaciones!
    }

    public readonly struct Data
    {
        private readonly int _value;

        public Data()
        {
            _value = 1;
        }

        public Data(int value)
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "El valor no puede ser menor que 1.");
            }

            _value = value;
        }

        public override string ToString() => _value.ToString();
    }
}
