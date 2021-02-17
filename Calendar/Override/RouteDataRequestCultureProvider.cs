using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calendar.Override
{
    public class RouteDataRequestCultureProvider : RequestCultureProvider
    {
        public int IndexOfCulture;
        public int IndexofUICulture;

        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            string culture = null;
            string uiCulture = null;

            var twoLetterCultureName = httpContext.Request.Path.Value.Split('/')[IndexOfCulture]?.ToString();
            var twoLetterUICultureName = httpContext.Request.Path.Value.Split('/')[IndexofUICulture]?.ToString();

            if (twoLetterUICultureName == "th")
            {
                culture = "th-TH";
            }
            else if (twoLetterUICultureName == "en")
            {
                culture = uiCulture = "en-US";
            }

            if (twoLetterCultureName == "th")
            {
                culture = "th-TH";
            }

            else if (twoLetterCultureName == "en")
            {
                culture = uiCulture = "en-US";
            }

            if (culture == null && uiCulture == null)
                return NullProviderCultureResult;

            if (culture != null && uiCulture == null)
            {
                uiCulture = culture;
            }

            if (culture == null && uiCulture != null)
            {
                culture = uiCulture;
            }

            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(uiCulture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);

            var providerResultCulture = new ProviderCultureResult(culture, uiCulture);

            return Task.FromResult(providerResultCulture);
        }
    }
}
