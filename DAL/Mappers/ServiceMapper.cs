using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class ServiceMapper
    {
        public static ServiceResponseModel ToServiceResponseModel(this Service model)
        {
            var tags = model.ServiceTags?.Select(x => x.Tag.ToTagResponseModel());
            var expertises = model.ServiceExpertises?.Select(x => x.Expertise.ToExpertiseResponseModel());
            return new ServiceResponseModel
            {
               Id = model.Id,
               Name = model.Name,
               ImageUrl = model.ImageUrl,
               Price = model.Price,
               Description = model.Description,
               RecommendedPeriodStartTime = model.RecommendedPeriodStartTime,
               RecommendedPeriodEndTime = model.RecommendedPeriodEndTime,
               Duration = model.Duration,
               ExperienceRequired = model.ExperienceRequired,
               Type = model.Type,
               NumberOfTreatment = model.NumberOfTreatment,
               ServiceTags = tags,
               ServiceExpertises = expertises
            };
        }
        public static Service ToService(this AddServiceRequestModel model)
        {
            return new Service
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Description = model.Description,
                RecommendedPeriodStartTime = model.RecommendedPeriodStartTime.ToUniversalTime(),
                RecommendedPeriodEndTime = model.RecommendedPeriodEndTime.ToUniversalTime(),
                Duration = model.Duration,
                ExperienceRequired = model.ExperienceRequired,
                Type = model.Type,
                NumberOfTreatment = model.NumberOfTreatment,
            };
        }
        public static Service ToService(this UpdateServiceRequestModel model, int id)
        {
            return new Service
            {
                Id = id,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Description = model.Description,
                RecommendedPeriodStartTime = model.RecommendedPeriodStartTime.ToUniversalTime(),
                RecommendedPeriodEndTime = model.RecommendedPeriodEndTime.ToUniversalTime(),
                Duration = model.Duration,
                ExperienceRequired = model.ExperienceRequired,
                Type = model.Type,
                NumberOfTreatment = model.NumberOfTreatment,
            };
        }
    }
}
