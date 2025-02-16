using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
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
        public async Task<ExpertiseResponseModel> AddAsync(AddExpertiseRequestModel expertise)
        {
            var expertises = await _repository.GetAllAsync();
            var existingExpertise = expertises.FirstOrDefault(x => x.ExpertiseName == expertise.ExpertiseName);
            if (existingExpertise != null)
            {
                throw new InvalidOperationException("Expertise name must be unique");
            }
            var result = await _repository.AddAsync(new Expertise
            {
                ExpertiseName = expertise.ExpertiseName,
            });
            return new ExpertiseResponseModel
            {
                Id = result.Id,
                ExpertiseName = result.ExpertiseName,
            };
        }

        public async Task<ExpertiseResponseModel> DeleteAsync(int id)
        {
            Expertise? expertise = await _repository.GetByIdAsync(id);
            if (expertise == null)
            {
                throw new KeyNotFoundException("Expertise not found.");
            }
            var result = await _repository.DeleteAsync(id);
            return new ExpertiseResponseModel
            {
                Id = result.Id,
                ExpertiseName = result.ExpertiseName,
            };
        }

        public async Task<IEnumerable<ExpertiseResponseModel>> GetAllAsync()
        {
            var expertises = await _repository.GetAllAsync();
            return expertises.Select(e => new ExpertiseResponseModel
            {
                Id = e.Id,
                ExpertiseName = e.ExpertiseName,
            });
        }

        public async Task<ExpertiseResponseModel> GetByIdAsync(int id)
        {
            Expertise? expertise = await _repository.GetByIdAsync(id);
            if (expertise == null)
            {
                throw new KeyNotFoundException("Expertise not found.");
            }
            return new ExpertiseResponseModel
            {
                Id = expertise.Id,
                ExpertiseName = expertise.ExpertiseName,
            };
        }

        public async Task<ExpertiseResponseModel> UpdateAsync(int id, UpdateExpertiseRequestModel expertise)
        {
            Expertise? existingExpertise = await _repository.GetByIdAsync(id);
            if (existingExpertise == null)
            {
                throw new KeyNotFoundException("Expertise not found.");
            }
            var expertises = await _repository.GetAllAsync();

            existingExpertise = expertises.FirstOrDefault(x => x.ExpertiseName == expertise.ExpertiseName);
            if (existingExpertise != null)
            {
                throw new InvalidOperationException("Expertise name must be unique");
            }
            var result = await _repository.UpdateAsync(new Expertise
            {
                Id = id,
                ExpertiseName = expertise.ExpertiseName
            });
            return new ExpertiseResponseModel
            {
                Id = result.Id,
                ExpertiseName = result.ExpertiseName,
            };
        }
    }
}
