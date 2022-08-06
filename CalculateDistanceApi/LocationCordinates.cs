using System;
namespace CalculateDistanceApi;

/// <summary>
/// Class to represent a single location point of Latitude & Longitude
/// </summary>
public class LocationCordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public LocationCordinates()
    { }
    public LocationCordinates(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}


