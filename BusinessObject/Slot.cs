﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("slot")]
    public class Slot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int slot_id { get; set; }

        public int employee_id { get; set; }

        //[ForeignKey(nameof(employee_id))]
        public Employee employee { get; set; }
        public string time { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
    }
}