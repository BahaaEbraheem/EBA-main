using Microsoft.Extensions.Localization;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OA.WASM.Shared.Helpers
{
    public static class DateHelpers
    {
        public static DateTime ConvertDueCulture(string datetimeStr, string cult)
        {
            var enCult = CultureInfo.GetCultureInfo("en-US");
            var arCult = CultureInfo.GetCultureInfo("ar-SY");
            var currCult = string.IsNullOrEmpty(cult) ? CultureInfo.GetCultureInfo("en-US") : CultureInfo.GetCultureInfo(cult);

            DateTime res;

            if (DateTime.TryParse(datetimeStr, currCult, DateTimeStyles.None, out res))
                return res;

            if (DateTime.TryParse(datetimeStr, enCult, DateTimeStyles.None, out res))
                return res;

            if (DateTime.TryParse(datetimeStr, arCult, DateTimeStyles.None, out res))
                return res;

            throw new ApplicationException(" No Matching Culture Date Format ");
        }

        public static string TimeSpan(DateTime date, IStringLocalizer<CommonResources> localizer)
        {
            var span = DateTime.Now - date;

            if (span.TotalSeconds < 60)
                return $"{localizer["Now"].Value}";
            if (span.TotalMinutes < 60)
                return $"{localizer["{0} minutes ago", Math.Floor(span.TotalMinutes)].Value}";
            if (span.TotalHours < 24)
                return $"{localizer["{0} hours ago", Math.Floor(span.TotalHours)].Value}";
            if (span.TotalDays < 31)
                return $"{localizer["{0} days ago", Math.Floor(span.TotalDays)].Value}";
            if (span.TotalDays < 365)
                return $"{localizer["about {0} month ago", Math.Floor((double)span.TotalDays / 30)].Value}";
            else
                return $"{localizer["about {0} year ago", Math.Floor((double)span.TotalDays / 365)].Value}";
        }

    }
}
