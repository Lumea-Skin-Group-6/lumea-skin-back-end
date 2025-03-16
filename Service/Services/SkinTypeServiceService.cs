using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using DAL.Mappers;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SkinTypeServiceService : ISkinTypeService
    {
        private readonly ISkinTypeRepository _repository;
        public SkinTypeServiceService(ISkinTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<SkinTypeResponseModel> AddAsync(AddSkinTypeRequestModel requestModel)
        {
            var skinTypes = await _repository.GetAllAsync();
            var existingModel = skinTypes.FirstOrDefault(x => x.Name == requestModel.Name);
            if (existingModel != null)
            {
                throw new InvalidOperationException("Skin type name must be unique");
            }

            var result = await _repository.AddAsync(requestModel.ToSkinType());
            return result.ToSkinTypeResponseModel();
        }

        public async Task<SkinTypeResponseModel> DeleteAsync(int id)
        {
            SkinType? skinType = await _repository.GetByIdAsync(id);
            if (skinType == null)
            {
                throw new KeyNotFoundException("Skin type not found.");
            }

            var result = await _repository.DeleteAsync(id);
            return result.ToSkinTypeResponseModel();
        }

        public async Task<IEnumerable<SkinTypeResponseModel>> GetAllAsync()
        {
            var skinTypes = await _repository.GetAllAsync();
            return skinTypes.Select(e => e.ToSkinTypeResponseModel());
        }

        public async Task<SkinTypeResponseModel> GetByIdAsync(int id)
        {
            SkinType? skinType = await _repository.GetByIdAsync(id);
            if (skinType == null)
            {
                throw new KeyNotFoundException("Skin type not found.");
            }

            return skinType.ToSkinTypeResponseModel();
        }

        public async Task<SkinTypeResponseModel> UpdateAsync(int id, UpdateSkinTypeRequestModel requestModel)
        {
            var skinTypes = await _repository.GetAllAsync();
            var existingModel = skinTypes.FirstOrDefault(x => x.Name == requestModel.Name);
            if (existingModel != null)
            {
                throw new InvalidOperationException("Skin type name must be unique");
            }

            var result = await _repository.UpdateAsync(requestModel.ToSkinType(id));
            return result.ToSkinTypeResponseModel();
        }
    }
}
