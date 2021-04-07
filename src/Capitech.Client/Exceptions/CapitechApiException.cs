using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Exceptions
{
    public class CapitechApiException : Exception
    {
        public CapitechApiException(string requestUri, string displayErrorMessage, string serverErrorMessage) 
            : base($"Capitech request to {requestUri} failed. Reason: {displayErrorMessage ?? ""}. Server Error: {serverErrorMessage ?? ""}")
        {
            DisplayErrorMessage = displayErrorMessage;
            ServerErrorMessage = serverErrorMessage;
        }

        public string RequestUri { get; set; }

        public string DisplayErrorMessage { get; set; }

        public string ServerErrorMessage { get; set; }
    }
}
