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

        public string Title { get; set; }
        public object Data { get; set; } 

        public ResponseDTO(int statusCode, string title, object data)
        {
            StatusCode = statusCode;
            Title = title;
            Data = data;
        }
    }
}
