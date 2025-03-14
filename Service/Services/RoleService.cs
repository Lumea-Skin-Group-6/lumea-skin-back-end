﻿using BusinessObject;
using DAL.DTO;
using DAL.DTOs.ResponseModel;
using Microsoft.IdentityModel.Tokens;
using Repository.HandleException;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _roleRepo;

        public RoleService(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }
        public ResponseModel GetAllRole()
        {
            try
            {
                Task<IEnumerable<Role>> taskListRole = _roleRepo.GetAllAsync();

                IEnumerable<Role> listRole = taskListRole.Result;

                if (listRole == null) 
                {
                    throw new ErrorException(404, "No roles!");
                }

                List<RoleResponse> roleList = new List<RoleResponse>();

                foreach (var role in listRole)
                {
                    RoleResponse responseDTO = new RoleResponse
                    {
                        RoleID = role.Id,
                        RoleName = role.Name
                    };

                    roleList.Add(responseDTO);
                }

                if (roleList.IsNullOrEmpty())
                {
                    roleList = new List<RoleResponse>();
                }

                return new ResponseModel(200, "List Roles:", roleList);
            } 
            catch (ErrorException ex)
            {
                var errorData = new ErrorResponseModel(ex.ErrorCode, ex.Message);
                return new ResponseModel(200, "There is no roles!", errorData);
            }
        }
    }
}
    