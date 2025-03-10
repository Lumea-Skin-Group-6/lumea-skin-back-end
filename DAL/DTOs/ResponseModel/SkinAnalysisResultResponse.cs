using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class SkinAnalysisResultResponse
    {
        public string SkinType { get; set; }
        public string Description { get; set; }
        public List<ServiceSuggestResponse> RecommendedServices { get; set; }
    }

    public class ServiceSuggestResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
