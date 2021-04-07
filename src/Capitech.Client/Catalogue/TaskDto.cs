using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class TaskDto
    {
        public int ClientId { get; set; }

        public int TaskId { get; set; }

        public int? DepartmentId { get; set; }

        public string TaskDescription { get; set; }

        /// <summary>
        /// 1 = Active, 0 = Disabled
        /// </summary>
        public int TaskStatus { get; set; }

        public int? CostCarrierId { get; set; }


    }
}
