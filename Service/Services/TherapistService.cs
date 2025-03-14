using BusinessObject;
using DAL.DTO;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
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
        private readonly ITherapistRepository repository;
        private readonly IUserRepository accountRepo;


        public TherapistService(ITherapistRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.accountRepo = userRepository;
        }

        public ResponseModel AddTherapist(TherapistRequest employee)
        {
            try
            {
                // Lấy danh sách tài khoản có RoleId == 5
                var validAccounts = accountRepo.GetAll().Where(e => e.RoleId == 5).ToList();
                var existAccount = validAccounts.Select(e => e.Id).ToHashSet();

                // Kiểm tra tất cả ID trong employee.AccountId
                var invalidIds = employee.AccountId.Where(id => !existAccount.Contains(id)).ToList();
                if (invalidIds.Any())
                {
                    throw new ErrorException(404, "Account not exist: " + string.Join(", ", invalidIds));
                }

                foreach (var item in employee.AccountId)
                {
                    Employee employee1 = new Employee
                    {
                        AccountId = item,
                        Type = employee.Type
                    };
                    repository.AddTherapist(employee1);
                }

                return new ResponseModel(200, "Add successfully!", employee);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Add Fail!", errorData);
            }
        }

        public ResponseModel DeleteTherapist(int id)
        {
            try
            {
                Employee employee = repository.GetTherapistById(id);

                if (employee == null)
                {
                    throw new ErrorException(404, "Employee not exist!");
                }

                Account account = accountRepo.GetAccountById(employee.AccountId);
                if (employee == null)
                {
                    throw new ErrorException(404, "Account not exist!");
                }

                repository.DeleteTherapist(employee);
                return new ResponseModel(200, "Delete Successfully!", "This is employee " + account.FullName);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Cannot Delete!", errorData);
            }
        }

        public ResponseModel GetAllTherapist()
        {
            try
            {
                List<Employee> listTherapist = repository.GetAllTherapist();

                List<Account> accounts = accountRepo.GetAll();

                List<TherapistResponse> responses = new List<TherapistResponse>();
                foreach (Employee employee in listTherapist)
                {
                    foreach (Account account in accounts)
                    {
                        if(employee.AccountId == account.Id)
                        {
                            TherapistResponse response = new TherapistResponse();
                            response.AccountID = employee.AccountId;
                            response.TherapistName = account.FullName;
                            response.TherapistType = employee.Type;
                            responses.Add(response);
                        }
                    }
                    
                }
                if (responses.IsNullOrEmpty())
                {
                    responses = new List<TherapistResponse>();
                }
                return new ResponseModel(200, "List Therapist", responses);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Cannot find Therapist!", errorData);
            }
        }

        public ResponseModel GetTherapistById(int id)
        {
            try
            {
                Employee employee = repository.GetTherapistById(id);

                if (employee == null)
                {
                    throw new ErrorException(404, "Employee not exist!");
                }

                Account account = accountRepo.GetAccountById(employee.AccountId);
                if (employee == null)
                {
                    throw new ErrorException(404, "Account not exist!");
                }

                TherapistResponse response = new TherapistResponse();
                response.AccountID = employee.AccountId;
                response.TherapistName = account.FullName;
                response.TherapistType = employee.Type;

                return new ResponseModel(200, "List Therapist", response);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Cannot find Therapist!", errorData);
            }
        }

        public ResponseModel UpdateTherapist(UpdateTherapistRequestModel updateRequest)
        {
            try
            {
                Employee exist = repository.GetTherapistById(updateRequest.employeeId);

                if (exist == null)
                {
                    throw new ErrorException(404, "Employee not exist!");
                }

                Account account = accountRepo.GetAccountById(updateRequest.AccountId);
                if (account == null)
                {
                    throw new ErrorException(404, "Account not exist!");
                }

                exist.AccountId = updateRequest.AccountId;
                exist.Type = updateRequest.Type;

                repository.UpdateTherapist(exist);
                

                return new ResponseModel(200, "Update successfully!", updateRequest);
            }
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(404, "Cannot find Therapist!", errorData);
            }
        }
    }
}
