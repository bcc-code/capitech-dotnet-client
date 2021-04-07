using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Time
{
    public class TimeTransactionDto
    {
        public int ClientId { get; set; }

        public int Uid { get; set; }

        public int EmployeeId { get; set; }

        public string Employee { get; set; }

        public DateTime? DateIn { get; set; }

        public TimeSpan? TimeIn { get; set; }

        public DateTime? DateOut { get; set; }

        public TimeSpan? TimeOut { get; set; }

        public int? DepartmentId { get; set; }

        public string Department { get; set; }

        public int? TaskId { get; set; }

        public string Task { get; set; }

        public int? ClassicDutyId { get; set; }

        public string ClassicDutyCode { get; set; }

        public string ClassicDuty { get; set; }

        public int? OrderId { get; set; }

        public string Order { get; set; }

        public int? ProjectId { get; set; }

        public string Project { get; set; }

        public int? SubProjectId { get; set; }

        public string SubProject { get; set; }

        public int? ProjectPhaseId { get; set; }

        public string ProjectPhase { get; set; }

        public int? ShiftId { get; set; }

        public string Shift { get; set; }

        public int? FreeDimension1Id { get; set; }

        public string FreeDimension1 { get; set; }

        public int? FreeDimension2Id { get; set; }

        public string FreeDimension2 { get; set; }

        public string FreeText { get; set; }

        public int? ApprovedLevelOne { get; set; }

        public int? ApprovedLevelTwo { get; set; }

        public int? ApprovedLevelThree { get; set; }

        public string ApprovedLevelFour { get; set; }
               
        public string ApprovedLevelOneBy { get; set; }
               
        public string ApprovedLevelTwoBy { get; set; }
               
        public string ApprovedLevelThreeBy { get; set; }
               
        public string ApprovedLevelFourBy { get; set; }

        public string ApprovedLevelOneOn { get; set; }

        public string ApprovedLevelTwoOn { get; set; }

        public string ApprovedLevelThreeOn { get; set; }

        public string ApprovedLevelFourOn { get; set; }

        public int? TimeCategoryId { get; set; }

        public string TimeCategory { get; set; }

        public string TimeCategoryTypeId { get; set; }

        public string TimeCategoryType { get; set; }

        public bool? TimeCategoryPayable { get; set;}

        public decimal? Qty { get; set; }

        public int? ExternalStatusCode { get; set; }

        public DateTimeOffset? LastUpdatedOn { get; set; }

        public string RecordStateKey { get; set; }

    }
}
