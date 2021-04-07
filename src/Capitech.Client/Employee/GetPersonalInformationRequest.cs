using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Employee
{
    public class GetPersonalInformationRequest : CapitechApiRequest
    {
        public int[] DepartmentIdFilter { get; set; }

        public int[] EmployeeIdFilter { get; set; }

        public bool? IncludeTimeActive { get; set; }

        public bool? IncludeTimePassive { get; set; }

        public bool? IncludeAbsenceActive { get; set; }

        public bool? IncludeAbsencePassive { get; set; }

        public bool? IncludePlanActive { get; set; }

        public bool? IncludePlanPassive { get; set; }

        /// <summary>
        /// "M", "K", null
        /// </summary>
        public string GenderFilter { get; set; }

        public int[] WageGroupIdFilter { get; set; }

        public int[] CostCarrierIdFilter { get; set; }

        /// <summary>
        /// A = Arbeider, F = Funksjonær, null
        /// </summary>
        public string StatisticsGroupCodeFilter { get; set; }
    }
}
