using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("DailyReport")]
    public class DailyReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal CancellationFees { get; set; }
        public decimal DiscountsApplied { get; set; }
        public decimal NetRevenue { get; set; }
        public int TotalBookings { get; set; }
        public int CancelledBookings { get; set; }
        public int CompletedBookings { get; set; }
    }
}
