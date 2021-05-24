using System;
using System.Collections.Generic;
using System.Text;

namespace cabinvoiceGenerator
{
 public class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }

        public ExceptionType etype;
        public CabInvoiceException(string message,ExceptionType etype) : base(message)
        {
            this.etype = etype;
        }
    }

}
