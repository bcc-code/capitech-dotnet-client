using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class GetProjectsRequest : CapitechApiRequest
    {
        public bool IncludePassive { get; set; }
    }
}
