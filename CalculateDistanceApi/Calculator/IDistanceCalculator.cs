using System;
namespace CalculateDistanceApi.Calculator
{
    public interface IDistanceCalculator
    {
        string Name { get; }
        DistanceCalculationResult CalculateDistance(LocationsToCalculateDistance geoCoordinates, bool isMetric);
    }
}

