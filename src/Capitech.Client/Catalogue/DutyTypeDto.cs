using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class DutyTypeDto
    {
        public int ClientId { get; set; }

        public int DutyTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int? SortNumber { get; set; }
    }
}
