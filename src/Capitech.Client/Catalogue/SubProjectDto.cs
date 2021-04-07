﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class SubProjectDto
    {
        public int ClientId { get; set; }

        public int SubProjectId { get; set; }

        public int ProjectId { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? PlannedFinishDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public bool UsesPhases { get; set; }

        public string ProjectLeader { get; set; }

        public string ProjectCustomer { get; set; }

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
