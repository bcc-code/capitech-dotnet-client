using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Catalogue
{
    public class GetSubProjectsRequest : CapitechApiRequest
    {
        public int ProjectId { get; set; }

    }
}
