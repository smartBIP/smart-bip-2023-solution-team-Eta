namespace JFP.Domain.Common;

public class Location
{
    public string Latitude { get; private set; }
    public string Longitude { get; private set;}

    public Location(string latitude, string longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
