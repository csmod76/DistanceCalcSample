using CalculateDistanceApi.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace CalculateDistanceApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GetDistanceController : ControllerBase
{
    private readonly ILogger<GetDistanceController> _logger;
    private IList<DistanceCalculatorFactory> _calculatorFactories;

    public GetDistanceController(ILogger<GetDistanceController> logger)
    {
        _logger = logger;
        _calculatorFactories = new List<DistanceCalculatorFactory>();

        //Register the list of Calculation classes available
        _calculatorFactories.Add(new GeodesicDistanceCalculation());
        _calculatorFactories.Add(new PythagorasDistanceCalculation());
    }

    /// <summary>
    /// Calculates the Distance based on 2 Geo locations supplied.
    /// </summary>
    /// <param name="locationsToCalculateDistance"></param>
    /// <returns>A Collection of results using different measurment techniques</returns>
    /// <remarks>
    /// Sample Response:
    ///{
    ///  "calculations": [
    ///    {
    ///      "name": "GeodesicDistanceCalculation",
    ///      "distance": 11119,
    ///      "units": "Kilometers"
    ///    },
    ///    {
    ///      "name": "PythagorasDistanceCalculation",
    ///      "distance": 11112,
    ///      "units": "Kilometers"
    ///    }
    ///  ]
    ///}
    /// </remarks>
    [HttpGet(Name = "GetDistance")]
    public DistanceCalculationResults Get([FromQuery] LocationsToCalculateDistance locationsToCalculateDistance)
    {
        var info = RegionalInformation.Get(Request);
        ///Failing to get the Regional information - default to Metric (km)
        var isMetric = info == null ? true : info.IsMetric;

        var results = new DistanceCalculationResults();

        foreach (var distanceCalculator in _calculatorFactories)
        {
            results.Calculations.Add(distanceCalculator.CalculateDistance(locationsToCalculateDistance, isMetric));
        }
        
        return results;
    }

}

