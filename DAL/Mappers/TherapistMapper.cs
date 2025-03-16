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
    public static class TherapistMapper
    {
        public static TherapistResponseModel ToTherapistResponseModel(this Account model)
        {
            return new TherapistResponseModel
            {
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                FullName = model.FullName,
                Gender = model.Gender,
                Phone = model.Phone,
                RoleId = model.RoleId,
                Id = model.Id,
                ImageUrl = model.ImageUrl,
                RoleName = model.Role.Name,
                Status = model.Status,
                Expertises = model.Employee?
                .TherapistExpertises.Select(x => x.ToTherapistExpertiseResponseModel()) ?? []
            };
        }

        public static TherapistExpertiseResponseModel ToTherapistExpertiseResponseModel(this TherapistExpertise therapistExpertise)
        {
            return new TherapistExpertiseResponseModel
            {
                Experience = therapistExpertise.experience,
                ExpertiseName = therapistExpertise.expertise.ExpertiseName,
                ExpertiseId = therapistExpertise.expertise_id,
            };
        }

        public static Account ToTherapist(this AddTherapistRequestModel requestModel)
        {
            Employee employee = new Employee
            {
                Type = "Therapist",
                Slots = [],
                TherapistExpertises = requestModel.TherapistExpertises
                .Select(x => new TherapistExpertise
                {
                    experience = x.Experience,
                    expertise_id = x.ExpertiseId,
                }).ToList()
            };
            return new Account
            {
                Status = requestModel.Status,
                RoleId = requestModel.RoleId,
                Phone = requestModel.Phone,
                Password = requestModel.Password,
                DateOfBirth = requestModel.DateOfBirth,
                IsLoggedIn = false,
                Email = requestModel.Email,
                FullName = requestModel.FullName,
                Gender = requestModel.Gender,
                ImageUrl = requestModel.ImageUrl,
                IsDeleted = false,
                Employee = employee
            };
        }
        public static Account ToAccount(this UpdateTherapistRequestModel requestModel, int id)
        {
            Employee employee = new Employee
            {
                Type = "Therapist",
                Slots = [],
                TherapistExpertises = requestModel.TherapistExpertises
                .Select(x => new TherapistExpertise
                {
                    experience = x.Experience,
                    expertise_id = x.ExpertiseId,
                }).ToList()
            };

            return new Account
            {
                Id = id,
                Status = requestModel.Status,
                RoleId = requestModel.RoleId,
                Phone = requestModel.Phone,
                DateOfBirth = requestModel.DateOfBirth,
                Email = requestModel.Email,
                FullName = requestModel.FullName,
                Gender = requestModel.Gender,
                ImageUrl = requestModel.ImageUrl,
            };
        }
    }
}
