namespace CalculateDistanceApi.Calculator
{
    public class GeodesicDistanceCalculation : DistanceCalculatorFactory
    {

        #region Public Overrides

        public override string Name => nameof(GeodesicDistanceCalculation);

        public override DistanceCalculationResult CalculateDistance(LocationsToCalculateDistance geoCoordinates, bool isMetric)
        {
            double sinLat1 = Math.Sin(DegreeToRadian(geoCoordinates.PointA.Latitude));
            double sinLat2 = Math.Sin(DegreeToRadian(geoCoordinates.PointB.Latitude));
            double cosinLat1 = Math.Cos(DegreeToRadian(geoCoordinates.PointA.Latitude));
            double cosinLat2 = Math.Cos(DegreeToRadian(geoCoordinates.PointB.Latitude));
            double cosLon = Math.Cos(DegreeToRadian(geoCoordinates.PointA.Longitude) 
                - DegreeToRadian(geoCoordinates.PointB.Longitude));

            double cosD = sinLat1 * sinLat2 + cosinLat1 * cosinLat2 * cosLon;
            var result = RadiusKm * Math.Acos(cosD);
            if (!isMetric)
            {
                result = result * 0.62137;
            }
            return new DistanceCalculationResult
            {
                Name = this.Name,
                Distance = Math.Round(result, 0),
                Units = isMetric ? DistanceUnits.Kilometers.ToString() : DistanceUnits.Miles.ToString(),
            };
        }

        #endregion

    }
}

