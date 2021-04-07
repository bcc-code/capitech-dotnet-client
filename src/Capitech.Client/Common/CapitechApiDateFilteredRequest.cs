using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Capitech.Client.Common
{
    public class CapitechApiDateFilteredRequest : CapitechApiRequest
    {
        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        public string FromDate { get; set; }

        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        public string ToDate { get; set; }

        public DateTime GetFromDate()
        {
            if (!string.IsNullOrEmpty(FromDate))
            {
                return DateTime.ParseExact(FromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            throw new Exception("FromDate is not defined in filter");
        }

        public DateTime GetToDate()
        {
            if (!string.IsNullOrEmpty(FromDate))
            {
                return DateTime.ParseExact(ToDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            throw new Exception("ToDate is not defined in filter");
        }

    }
}
