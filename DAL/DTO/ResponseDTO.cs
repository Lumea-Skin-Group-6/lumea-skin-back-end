using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class ResponseDTO
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }
        public object Data { get; set; } 

        public ResponseDTO(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
