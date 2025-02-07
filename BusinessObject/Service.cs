using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Service")]
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime RecommendedPeriodStartTime { get; set; }
        public DateTime RecommendedPeriodEndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string ExperienceRequired { get; set; }
        public string Type { get; set; }
        public int NumberOfTreatment { get; set; }

        public ICollection<ServiceTag> ServiceTags { get; set; }
        public ICollection<ServiceExpertise> ServiceExpertises { get; set; }
    }

}
