using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class DepartmentDto
    {
        public int ClientId { get; set; }

        public int DepartmentId { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
