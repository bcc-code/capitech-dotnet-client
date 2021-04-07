using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class GetTasksRequest : CapitechApiRequest
    {
        public int DepartmentId { get; set; }

    }
}
