using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Time
{
    public class GetTimeTransactionsRequest : CapitechApiDateFilteredRequest
    {

        public int[] ApprovedLevelFilter { get; set; }
      
        public int[] EmployeeIdFilter { get; set; }

        public int[] DepartmentIdFilter { get; set; }

        public int[] TaskIdFilter { get; set; }

        public int[] OrderIdFilter { get; set; }
        
        public int[] DutyIdFilter { get; set; }

        public int[] ProjectIdFilter { get; set; }

        public int[] SubProjectIdFilter { get; set; }

        public int[] ProjectPhaseIdFilter { get; set; }

        public int[] FreeDimension1Filter { get; set; }

        public int[] FreeDimension2Filter { get; set; }

        public int[] TimeCategoryIdFilter { get; set; }

        public string[] TimeCategoryTypeIdFilter { get; set; }

        public bool? IncludePayableCategory { get; set; }

        public bool? IncludeElementsWithExternalStatusCodeNull { get; set; }

        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        public string LastUpdatedGreaterThanOrEqualToFilter { get; set; }
    }
}
