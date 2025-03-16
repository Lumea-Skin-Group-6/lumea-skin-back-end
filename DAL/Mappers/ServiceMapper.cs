using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;

namespace DAL.Mappers
{
    public static class ServiceMapper
    {
        public static ServiceResponseModel ToServiceResponseModel(this ServiceModel model)
        {
            var skinType = model.SkinTypeServices?.Select(x => x.SkinType.ToSkinTypeResponseModel());
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
                ServiceSkinTypes = skinType,
                ServiceExpertises = expertises
            };
        }

        public static ServiceModel ToService(this AddServiceRequestModel model)
        {
            return new ServiceModel
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
                RecommendedAge = model.recommend_age
            };
        }

        public static ServiceModel ToService(this UpdateServiceRequestModel model, int id)
        {
            return new ServiceModel
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
                RecommendedAge = model.recommend_age
            };
        }
    }
}