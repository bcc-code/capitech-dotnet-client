﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.OperationalPlan
{
    public class OperationalPlanDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public string CreatedBy { get; set;}

        public DateTimeOffset? UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Notes { get; set;}

        public DateTimeOffset? Start { get; set;}

        public DateTimeOffset? End { get; set; }

        public string Period { get; set; }

        public string ShortDutyDescription { get; set; }

        public string LongDutyDescription { get; set; }

        public decimal? Hours { get; set; }

        public DateTimeOffset? NewStart { get; set; }

        public DateTimeOffset? NewEnd { get; set; }

        public decimal? NewHours { get; set; }

        public int Count { get; set; }

        public int? SubstituteDutyId { get; set; }

        public int? PreviousDutyId { get; set; }

        public int? SubstituteProviderId { get; set; }

        public string SubstituteProviderName { get; set; }

        public int? ExchangeDutyId { get; set; }

        public int? ShiftRotationRollOutId { get; set; }

        public int? DutyDefinitionId { get; set; }

        public int? EmployeeId { get; set; }

        public string EmployeeFullName { get; set; }

        public int? EmployeeDepartmentId { get; set; }

        public int? DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int? CompetenceRoleId { get; set; }

        public string CompetenceRoleName { get; set; }

        public int? TaskId { get; set; }

        public string TaskName { get; set; }

        public int? OrderId { get; set; }

        public string OrderName { get; set; }

        public int? ProjectId { get; set; }

        public string ProjectName { get; set; }

        public int? SubProjectId { get; set; }

        public string SubProjectName { get; set; }

        public int? PhaseId { get; set; }

        public string PhaseName { get; set; }

        public int? FreeDimension1Id { get; set; }

        public string FreeDimension1Name { get; set; }

        public int? FreeDimension2Id { get; set; }

        public string FreeDimension2Name { get; set; }


    }
}
