namespace Novedades.csharp10;

internal class Records
{
    public static void DoStuff()
    {
        var dni = new DNI()
        {
            Value = "50320650P"
        };

        // person1.FirstName = "Paco"; error de compilación!

        var dni2 = new DNI()
        {
            Value = "50320650P"
        };

        if (dni == dni2) //True, comparación por valor
        {
            var dni3 = dni2 with { Value = "0000000000J" };

            if (dni3 == dni2) //False, with copia datos sin modificar los originales
            {
                //No debería estar aquí
            }
        }
    }

    public record struct DNI
    {
        public string Value { get; init; }
    }
}
