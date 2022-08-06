using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CalculateDistanceApi
{
    /// <summary>
    /// Static class to get the Regional information from the Http Request fo the client
    /// </summary>
    public static class RegionalInformation
    {
        public static RegionInfo? Get(HttpRequest request)
        {
            var locale = request.HttpContext.Features.Get<IRequestCultureFeature>();
            if (locale == null)
            {
                return null;
            }
            var BrowserCulture = locale.RequestCulture.UICulture.ToString();
            return new RegionInfo(BrowserCulture);
        }
    }
}
