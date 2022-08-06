using System;
namespace CalculateDistanceApi;

/// <summary>
/// Class representing the object data passed in to the API 
/// Supplying the 2 locations for the distance to be calculated
/// </summary>
public class LocationsToCalculateDistance
{
    public LocationCordinates PointA { get; set; }
    public LocationCordinates PointB { get; set; }

    public LocationsToCalculateDistance()
    {
        PointA = new LocationCordinates();
        PointB = new LocationCordinates();
    }
}

