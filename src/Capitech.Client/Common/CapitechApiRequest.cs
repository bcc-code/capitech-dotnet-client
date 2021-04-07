using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Common
{
    public class CapitechApiRequest
    {
        /// <summary>
        /// Access token, automatically set by ApiRequestHandler
        /// </summary>
        public string AccessToken { get; set; }

        public int ClientId { get; set; }

    }
}
