using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class SkinTypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
