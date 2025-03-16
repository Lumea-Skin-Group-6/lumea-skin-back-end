using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class ExpertiseMapper
    {
        public static ExpertiseResponseModel ToExpertiseResponseModel(this Expertise model)
        {
            return new ExpertiseResponseModel
            {
                Id = model.Id,
                ExpertiseName = model.ExpertiseName,
            };
        }

        public static SkinTypeResponse ToSkinTypeResponseModel(this SkinType model)
        {
            return new SkinTypeResponse
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static Expertise ToExpertise(this AddExpertiseRequestModel requestModel)
        {
            return new Expertise
            {
                ExpertiseName = requestModel.ExpertiseName,
            };
        }
        public static Expertise ToExpertise(this UpdateExpertiseRequestModel requestModel, int id)
        {
            return new Expertise
            {
                Id = id,
                ExpertiseName = requestModel.ExpertiseName,
            };
        }
    }
}
