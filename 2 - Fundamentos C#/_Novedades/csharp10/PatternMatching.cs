namespace Novedades.csharp10;

public static class PatternMatching
{
    public enum Kind
    {
        Driving,
        Drinking,
    }

    public enum Country
    {
        USA,
        Spain,
    }

    public class Location
    {
        public Country Country { get; set; }
    }

    public class Activity
    {
        public Kind Kind { get; set; }
        public Location Location { get; set; } = new Location();
    }

    public static int GetAdultAge(Activity activity)
    {
        return activity switch
        {
            { Location.Country: Country.Spain } => 18,
            { Location.Country: Country.USA, Kind: Kind.Drinking } => 21,
            { Location.Country: Country.USA, Kind: Kind.Driving } => 16,
            _ => 20,
        };
    }
}


