using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Absence
{
    public class GetAbsenceRequest : CapitechApiDateFilteredRequest
    {
               
        public string UpdateFromDateFilter { get; set; }

        public int[] AbsenceIdFilter { get; set; }

        public int[] EmployeeIdFilter { get; set; }

        public int[] DepartmentIdFilter { get; set; }

        public string[] AbsenceCodeFilter { get; set; }

        public int[] AbsenceTypeFilter { get; set; }

    }
}
