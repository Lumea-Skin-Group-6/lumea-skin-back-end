using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("daily_reports")]
    public class DailyReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("report_date")] public DateTime Date { get; set; }

        [Column("total_revenue")] public decimal TotalRevenue { get; set; }

        [Column("cancellation_fees")] public decimal CancellationFees { get; set; }

        [Column("discounts_applied")] public decimal DiscountsApplied { get; set; }

        [Column("net_revenue")] public decimal NetRevenue { get; set; }

        [Column("total_bookings")] public int TotalBookings { get; set; }

        [Column("cancelled_bookings")] public int CancelledBookings { get; set; }

        [Column("completed_bookings")] public int CompletedBookings { get; set; }
    }
}