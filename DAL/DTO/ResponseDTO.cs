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
        public object Data { get; set; } 

        public ResponseDTO(int statusCode, object data)
        {
            StatusCode = statusCode;
            Data = data;
        }
    }
}
