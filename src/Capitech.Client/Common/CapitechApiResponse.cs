using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Common
{
    public class CapitechApiResponse<TContent>
    {
        public bool Success { get; set; }

        public string ServerErrorMessage { get; set; }

        public string DisplayErrorMessage { get; set; }

        public TContent[] Content { get; set; }
    }
}
