using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Slot")]
    public class Slot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        //[ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
