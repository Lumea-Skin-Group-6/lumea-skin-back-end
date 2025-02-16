using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class ErrorResponseDTO
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        public ErrorResponseDTO(int errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }
    }
}
