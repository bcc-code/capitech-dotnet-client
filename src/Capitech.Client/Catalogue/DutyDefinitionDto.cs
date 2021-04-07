using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class DutyDefinitionDto
    {
        public int ClientId { get; set; }

        public int DutyDefinitionId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public struct DutyDefinitionTime
        {
            public int Hour { get; set; }

            public int Minute { get; set; } 

            public int Second { get; set; }

            public bool IsEmpty { get; set; }

            public TimeSpan? AsTimeSpan()
            {
                if (!IsEmpty)
                {
                    return new TimeSpan(Hour, Minute, Second);
                }
                return null;
            }
        }

        public DutyDefinitionTime? Start { get; set; }

        public DutyDefinitionTime? End { get; set; }

        public DutyDefinitionTime? BreakStart { get; set; }

        public DutyDefinitionTime? BreakEnd { get; set; }

        public decimal? Hours { get; set; }

        public int? SortNumber { get; set; }

        public int? DutyTypeId { get; set; }

        public int? CompetenceId { get; set; }
    }


}
