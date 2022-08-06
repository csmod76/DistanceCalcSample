using CalculateDistanceApi;
using CalculateDistanceApi.Calculator;

namespace DistanceCalculationTests;

[TestClass]
public class CalculationTests
{
    [TestMethod]
    public void TestGeodesicDistanceCalculationKm()
    {
        var geoCoordinates = new LocationsToCalculateDistance
        {
             PointA = new LocationCordinates(53.297975, -6.372663),
             PointB = new LocationCordinates(41.385101, -81.440440)
        };

        var calculator = new GeodesicDistanceCalculation();
        var result = calculator.CalculateDistance(geoCoordinates, true);

        Assert.AreEqual(5536, result.Distance);
    }

    [TestMethod]
    public void TestGeodesicDistanceCalculationMiles()
    {
        var geoCoordinates = new LocationsToCalculateDistance
        {
            PointA = new LocationCordinates(53.297975, -6.372663),
            PointB = new LocationCordinates(41.385101, -81.440440)
        };

        var calculator = new GeodesicDistanceCalculation();
        var result = calculator.CalculateDistance(geoCoordinates, false);

        Assert.AreEqual(3440, result.Distance);
    }

    [TestMethod]
    public void TestPythagorasDistanceCalculationKm()
    {
        var geoCoordinates = new LocationsToCalculateDistance
        {
            PointA = new LocationCordinates(0, 0),
            PointB = new LocationCordinates(0, 100)
        };

        var calculator = new PythagorasDistanceCalculation();
        var result = calculator.CalculateDistance(geoCoordinates, true);

        Assert.AreEqual(11112, result.Distance);
    }

    [TestMethod]
    public void TestPythagorasDistanceCalculationMiles()
    {
        var geoCoordinates = new LocationsToCalculateDistance
        {
            PointA = new LocationCordinates(0, 0),
            PointB = new LocationCordinates(0, 100)
        };

        var calculator = new PythagorasDistanceCalculation();
        var result = calculator.CalculateDistance(geoCoordinates, false);

        Assert.AreEqual(6905, result.Distance);
    }
}
