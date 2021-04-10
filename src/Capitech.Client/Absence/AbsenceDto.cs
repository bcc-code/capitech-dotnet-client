using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Absence
{
    public class AbsenceDto
    {
        public int AbsenceId { get; set; }

        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        public string Employee { get; set; }

        public string AbsenceCode { get; set; }

        public string AbsenceDescription { get; set; }

        public int AbsenceType { get; set; }

        public DateTimeOffset? FromDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public decimal? Hours { get; set; }

        public decimal? AbsencePercent { get; set; }

        public int? DepartmentId { get; set; }

        public string Department { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}
