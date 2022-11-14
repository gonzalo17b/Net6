namespace Novedades.csharp8;

public class PatternMatching
{
    public enum Country
    {
        USA,
        Spain,
    }

    public enum ActivityKind
    {
        Drinking,
        Shooting,
        Driving,
    }

    public class Activity
    {
        public Country Country { get; set; }
        public ActivityKind Kind { get; set; }
    }

    public static int GetAdultAge(Country country)
    {
        return country switch
        {
            Country.Spain => 18,
            Country.USA => 21,
            _ => 20,
        };
    }

    public static int GetAdultAge(Activity activity)
    {
        return activity switch
        {
            { Country: Country.Spain } => 18,
            { Country: Country.USA, Kind: ActivityKind.Driving } => 16,
            { Country: Country.USA, Kind: ActivityKind.Shooting } => 16,
            { Country: Country.USA, Kind: ActivityKind.Drinking } => 21,
            _ => 20,
        };
    }
}


