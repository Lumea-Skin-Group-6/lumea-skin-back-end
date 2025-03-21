using BusinessObject;
using DAL.DTO;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using DAL.Mappers;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Repository.HandleException;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TherapistService : ITherapistService
    {
        private readonly ITherapistRepository _repository;
        private readonly IAccountRepository _accountRepository;
        public TherapistService(ITherapistRepository repository, IAccountRepository accountRepository)
        {
            _repository = repository;
            _accountRepository = accountRepository;
        }
        public async Task<TherapistResponseModel> AddAsync(AddTherapistRequestModel requestModel)
        {
            var accounts = await _accountRepository.GetAllAsync();
            if (accounts.FirstOrDefault(x => x.Email.ToLower() == requestModel.Email.ToLower()) != null)
            {
                throw new InvalidOperationException("Therapist email must be unique");
            }
            requestModel.Password = BCrypt.Net.BCrypt.HashPassword(requestModel.Password);
            var result = await _repository.AddAsync(requestModel.ToTherapist());
            return result.ToTherapistResponseModel();
        }

        public async Task<TherapistResponseModel> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return result.ToTherapistResponseModel();
        }

        public async Task<IEnumerable<TherapistResponseModel>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result.Select(x => x.ToTherapistResponseModel());
        }

        public async Task<IEnumerable<TherapistResponseModel>> GetAllTherapistByListExpertiseID(ICollection<int> expertiseID)
        {
            var result = await _repository.GetAllTherapistByListExpertiseID(expertiseID);
            return result.Select(x => x.ToTherapistResponseModel());
        }

        public async Task<TherapistResponseModel> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null) throw new KeyNotFoundException();
            return result.ToTherapistResponseModel();
        }


        public async Task<TherapistResponseModel> UpdateAsync(int id, UpdateTherapistRequestModel requestModel)
        {
            var accounts = await _accountRepository.GetAllAsync();
            if (accounts.FirstOrDefault(x => x.Email.ToLower() == requestModel.Email.ToLower()) != null)
            {
                throw new InvalidOperationException("Therapist email must be unique");
            }
            var result = await _repository.UpdateAsync(requestModel.ToAccount(id));
            return result.ToTherapistResponseModel();
        }




    }
}
