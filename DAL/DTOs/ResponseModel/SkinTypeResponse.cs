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
        public string Description { get; set; }
        public sbyte MinDry { get; set; }
        public sbyte MaxDry { get; set; }
        public sbyte MinOily { get; set; }
        public sbyte MaxOily { get; set; }
        public sbyte MinSensitive { get; set; }
        public sbyte MaxSensitive { get; set; }
    }
}
