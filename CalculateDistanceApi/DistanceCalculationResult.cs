namespace CalculateDistanceApi;

/// <summary>
/// The Returned Results Object containg list of results
/// </summary>
public class DistanceCalculationResults
{
    public List<DistanceCalculationResult> Calculations { get; set; }

    public DistanceCalculationResults()
    {
        Calculations = new List<DistanceCalculationResult>();
    }
}

/// <summary>
/// A Result from a Distance Calculation
/// </summary>
public class DistanceCalculationResult
{
    /// <summary>
    /// The name of the Calculator used
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The calculated distance
    /// </summary>
    public double Distance { get; set; }
    /// <summary>
    /// The units returned - Miles / Kilometers - based upon the locale client browser
    /// </summary>
    public string Units { get; set; }

}