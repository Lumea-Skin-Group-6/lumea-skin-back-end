using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.HandleException
{
    public class ShiftException : Exception
    {
        public int ErrorCode { get; }

        public ShiftException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public ShiftException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
