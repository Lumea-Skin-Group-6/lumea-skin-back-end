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
    public static class SkinTypeMapper
    {
        public static SkinTypeResponseModel ToSkinTypeResponseModel(this SkinType model)
        {
            return new SkinTypeResponseModel
            {
                Id = model.Id,
                Name = model.Name,
                MaxSensitive = model.MaxSensitive,
                MinSensitive = model.MinSensitive,
                MaxDry = model.MaxDry,
                MaxOily = model.MaxOily,
                Description = model.Description,
                MinDry = model.MinDry,
                MinOily = model.MinOily
            };
        }

        public static SkinType ToSkinType(this AddSkinTypeRequestModel requestModel)
        {
            return new SkinType
            {
                MaxDry = requestModel.MaxDry,
                Description = requestModel.Description,
                MaxOily = requestModel.MaxOily,
                MinOily = requestModel.MinOily,
                MinDry = requestModel.MinDry,
                MinSensitive = requestModel.MinSensitive,
                MaxSensitive = requestModel.MaxSensitive,
                Name = requestModel.Name
            };
        }
        public static SkinType ToSkinType(this UpdateSkinTypeRequestModel requestModel, int id)
        {
            return new SkinType
            {
                Id = id,
                MaxDry = requestModel.MaxDry,
                Description = requestModel.Description,
                MaxOily = requestModel.MaxOily,
                MinOily = requestModel.MinOily,
                MinDry = requestModel.MinDry,
                MinSensitive = requestModel.MinSensitive,
                MaxSensitive = requestModel.MaxSensitive,
                Name = requestModel.Name
            };
        }
    }
}
