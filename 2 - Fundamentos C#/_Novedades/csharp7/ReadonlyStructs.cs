namespace Novedades.csharp7
{
    public class ReadonlyStructs
    {
        public readonly struct Data
        {
            private string Value { get; }

            public Data(string value)
            {
                Value = value;
            }

            public override string ToString()
            {
                // Value = ""; Not valid!
                return Value;
            }
        }
    }
}
