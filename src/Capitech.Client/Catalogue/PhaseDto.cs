using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class PhaseDto
    {
        public int ClientId { get; set; }

        public int PhaseId { get; set; }

        public int ProjectId { get; set; }

        public int SubProjectId { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? PlannedFinishDate { get; set; }

        public DateTimeOffset? FinishDate { get; set; }


        /// <summary>
        /// AK (active), PA (passive), AV (closed), IP (not started)
        /// </summary>
        public string Status { get; set; }

        public decimal? HourlyRate { get; set;}

        public decimal? PercentagePart { get; set; }

        public int UniqueId { get; set; }

        public string AlphanumericCode { get; set; }

        public string Description2 { get; set; }

        
    }
}
