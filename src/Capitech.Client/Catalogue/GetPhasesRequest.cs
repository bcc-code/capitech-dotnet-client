using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class GetPhasesRequest : CapitechApiRequest
    {
        public int ProjectId { get; set; }

        public int SubProjectId { get; set; }
    }
}
