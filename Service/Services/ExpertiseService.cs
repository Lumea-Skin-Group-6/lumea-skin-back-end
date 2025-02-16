using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using DAL.Mappers;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ExpertiseService : IExpertiseService
    {
        private readonly IExpertiseRepository _repository;
        public ExpertiseService(IExpertiseRepository repository)
        {
            _repository = repository;
        }
        public async Task<ExpertiseResponseModel> AddAsync(AddExpertiseRequestModel requestModel)
        {
            var expertises = await _repository.GetAllAsync();
            var existingExpertise = expertises.FirstOrDefault(x => x.ExpertiseName == requestModel.ExpertiseName);
            if (existingExpertise != null)
            {
                throw new InvalidOperationException("Expertise name must be unique");
            }
            var result = await _repository.AddAsync(requestModel.ToExpertise());
            return result.ToExpertiseResponseModel();
        }

        public async Task<ExpertiseResponseModel> DeleteAsync(int id)
        {
            Expertise? expertise = await _repository.GetByIdAsync(id);
            if (expertise == null)
            {
                throw new KeyNotFoundException("Expertise not found.");
            }
            var result = await _repository.DeleteAsync(id);
            return result.ToExpertiseResponseModel();
        }

        public async Task<IEnumerable<ExpertiseResponseModel>> GetAllAsync()
        {
            var expertises = await _repository.GetAllAsync();
            return expertises.Select(e => e.ToExpertiseResponseModel());
        }

        public async Task<ExpertiseResponseModel> GetByIdAsync(int id)
        {
            Expertise? expertise = await _repository.GetByIdAsync(id);
            if (expertise == null)
            {
                throw new KeyNotFoundException("Expertise not found.");
            }
            return expertise.ToExpertiseResponseModel();
        }

        public async Task<ExpertiseResponseModel> UpdateAsync(int id, UpdateExpertiseRequestModel requestModel)
        {
            Expertise? existingExpertise = await _repository.GetByIdAsync(id);
            if (existingExpertise == null)
            {
                throw new KeyNotFoundException("Expertise not found.");
            }
            var expertises = await _repository.GetAllAsync();

            existingExpertise = expertises.FirstOrDefault(x => x.ExpertiseName == requestModel.ExpertiseName && x.Id != id);
            if (existingExpertise != null)
            {
                throw new InvalidOperationException("Expertise name must be unique");
            }
            var result = await _repository.UpdateAsync(requestModel.ToExpertise(id));
            return result.ToExpertiseResponseModel();
        }
    }
}
