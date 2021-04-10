using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class ProjectDto
    {
        public int ClientId { get; set; }

        public int ProjectId { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? PlannedFinishDate { get; set; }

        public DateTimeOffset? FinishDate { get; set; }

        public bool UsesSubProjects { get; set; }

        /// <summary>
        /// AK (active), PA (passive), AV (closed), IP (not started)
        /// </summary>
        public string Status { get; set; }

        public decimal? HourlyRate { get; set;}

        public string ProjectCustomer { get; set; }

        public string ProjectLeader { get; set; }

        public int UniqueId { get; set; }

        public string AlphanumericCode { get; set; }

        public string Description2 { get; set; }

        
    }
}
