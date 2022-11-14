﻿namespace Novedades.csharp9;

internal static class Records
{
    public static void DoStuff()
    {
        var person1 = new Person()
        {
            FirstName = "Pepe",
            LastName = "Pérez",
        };

        // person1.FirstName = "Paco"; // error de compilación!

        var person2 = new Person()
        {
            FirstName = "Pepe",
            LastName = "Pérez",
        };

        if (person1 == person2) //True, comparación por valor
        {
            var person3 = person2 with { LastName = "Martínez" };

            if (person3 == person2) //False, with copia datos sin modificar los originales
            {
                //No debería estar aquí
            }
        }
    }

    public record Person
    {
        public string FirstName { get; init; } = string.Empty; //Init only setter!
        public string LastName { get; init; } = string.Empty;
    }
}
