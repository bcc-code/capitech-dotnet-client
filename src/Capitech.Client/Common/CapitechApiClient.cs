using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Common
{
    public class CapitechApiClient
    { 
        public CapitechApiClient(CapitechApiRequestHandler api)
        {
            Api = api;
        }

        protected CapitechApiRequestHandler Api { get; }
    }
}
