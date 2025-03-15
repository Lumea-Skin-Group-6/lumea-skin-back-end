using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class ServiceResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string ImageUrl { get; set; } = "";

        public decimal Price { get; set; }

        public string Description { get; set; } = "";

        public DateTime RecommendedPeriodStartTime { get; set; }

        public DateTime RecommendedPeriodEndTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string ExperienceRequired { get; set; } = "";

        public string Type { get; set; }

        public int NumberOfTreatment { get; set; }

        public IEnumerable<SkinTypeResponse> ServiceSkinTypes { get; set; } = [];
        public IEnumerable<ExpertiseResponseModel> ServiceExpertises { get; set; } = [];
    }
}
