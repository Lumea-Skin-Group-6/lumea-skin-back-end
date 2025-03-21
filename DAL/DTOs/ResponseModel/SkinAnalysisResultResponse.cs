using BusinessObject;
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
        public List<ServiceResponseModel> RecommendedServices { get; set; }
    }
}
