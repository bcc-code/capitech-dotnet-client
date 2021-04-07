using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.OperationalPlan
{
    public class OperationalPlanRequest : CapitechApiDateFilteredRequest
    {

        public int[] EmployeeIdFilter { get; set; }

        public int[] DepartmentIdFilter { get; set; }

        public int[] CompetenceIdFilter { get; set; }

        public int[] TaskIdFilter { get; set; }

        public int[] OrderIdFilter { get; set; }

        public int[] ProjectIdFilter { get; set; }

        public int[] SubProjectIdFilter { get; set; }

        public int[] PhaseIdFilter { get; set; }

        public int[] FreeDimension1IdFilter { get; set; }

        public int[] FreeDimension2IdFilter { get; set; }

        public int[] SubstituteProviderIdFilter { get; set; }
    }
}
