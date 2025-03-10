using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("services")]
    public class ServiceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("service_name")] public string Name { get; set; }

        [Column("image_url")] public string ImageUrl { get; set; }

        [Column("price")] public decimal Price { get; set; }

        [Column("description")] public string Description { get; set; }

        [Column("recommended_start_time")] public DateTime RecommendedPeriodStartTime { get; set; }

        [Column("recommended_end_time")] public DateTime RecommendedPeriodEndTime { get; set; }

        [Column("duration")] public TimeSpan Duration { get; set; }

        [Column("experience_required")] public string ExperienceRequired { get; set; }

        [Column("recommended_age")] public int RecommendedAge { get; set; }

        [Column("service_type")] public string Type { get; set; }

        [Column("number_of_treatments")] public int NumberOfTreatment { get; set; }

        public ICollection<SkinTypeService> SkinTypeServices { get; set; }
        public ICollection<ServiceExpertise> ServiceExpertises { get; set; }
    }
}