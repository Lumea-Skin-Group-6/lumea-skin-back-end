﻿using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class AccountMapper
    {
        public static AccountResponseModel ToAccountResponseModel(this Account model)
        {
            return new AccountResponseModel
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
                Status = model.Status
            };
        }

        public static Account ToAccount(this AddAccountRequestModel requestModel)
        {
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
            };
        }
        public static Account ToAccount(this UpdateAccountRequestModel requestModel, int id)
        {
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
