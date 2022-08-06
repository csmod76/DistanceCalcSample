namespace CalculateDistanceApi.Calculator
{
    public class PythagorasDistanceCalculation : DistanceCalculatorFactory
    {

        #region Public Overrides
        public override string Name => nameof(PythagorasDistanceCalculation);

        public override DistanceCalculationResult CalculateDistance(LocationsToCalculateDistance geoCoordinates, bool isMetric)
        {
            double theta = geoCoordinates.PointA.Longitude - geoCoordinates.PointB.Longitude;
            double distance = Math.Sin(DegreeToRadian(geoCoordinates.PointA.Latitude))
                * Math.Sin(DegreeToRadian(geoCoordinates.PointB.Latitude))
                + Math.Cos(DegreeToRadian(geoCoordinates.PointA.Latitude))
                * Math.Cos(DegreeToRadian(geoCoordinates.PointB.Latitude)) * Math.Cos(DegreeToRadian(theta));
            distance = Math.Acos(distance);
            distance = RadianToDegree(distance);
            distance = distance * 60 * 1.852;

            if (!isMetric)
            {
                distance = distance * 0.62137;
            }
            return new DistanceCalculationResult
            {
                Name = this.Name,
                Distance = Math.Round(distance, 0),
                Units = isMetric ? DistanceUnits.Kilometers.ToString() : DistanceUnits.Miles.ToString(),
            };
        }

        #endregion
   
    }
}

