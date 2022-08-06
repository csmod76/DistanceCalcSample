namespace CalculateDistanceApi.Calculator
{
    public abstract class DistanceCalculatorFactory : IDistanceCalculator
    {
        #region Protected Members / Methods
        /// <summary>
        /// Fixed value Radius used by calculators
        /// </summary>
        protected double RadiusKm => 6371;

        /// <summary>
        /// Function to convert Degrees to Radians
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        protected double DegreeToRadian(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        /// <summary>
        /// Function to convert Radians to degrees
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        protected double RadianToDegree(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        #endregion

        #region Abstract methods#

        public abstract string Name { get; }
        public abstract DistanceCalculationResult CalculateDistance(LocationsToCalculateDistance geoCoordinates, bool isMetric);

        #endregion
    }
}

