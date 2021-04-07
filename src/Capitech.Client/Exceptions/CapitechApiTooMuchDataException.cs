using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech.Client.Exceptions
{
    public class CapitechApiTooMuchDataException : CapitechApiException
    {
        public CapitechApiTooMuchDataException(string requestUri, string displayErrorMessage, string serverErrorMessage) 
            : base(requestUri, displayErrorMessage, serverErrorMessage)
        {
        }
    }
}
