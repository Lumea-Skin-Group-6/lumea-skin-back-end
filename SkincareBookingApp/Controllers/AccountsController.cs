﻿using DAL.DTOs.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service.Interfaces;
using SkincareBookingApp.Helpers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace SkincareBookingApp.Controllers
{
    [Route("api/accounts")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [ApiController]
    public class AccountsController : ODataController
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [EnableQuery]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all accounts")]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _accountService.GetAllAsync();
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get accounts successfully",
                accounts);
        }

        [EnableQuery]
        [HttpGet("{accountId:int}")]
        [SwaggerOperation(Summary = "Get account by ID")]
        public async Task<IActionResult> GetExpertise([FromRoute] int accountId)
        {
            try
            {
                var account = await _accountService.GetByIdAsync(accountId);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get account successfully",
                    account);
            } catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add a new account")]
        public async Task<IActionResult> Create([FromBody] AddAccountRequestModel requestModel)
        {
            try
            {
                var account = await _accountService.AddAsync(requestModel);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.Created, "Add account successfully",
                    account);
            } catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{accountId:int}")]
        [SwaggerOperation(Summary = "Update an account")]
        public async Task<IActionResult> Update([FromBody] UpdateAccountRequestModel requestModel,
            [FromRoute] int accountId)
        {
            try
            {
                var expertise = await _accountService.UpdateAsync(accountId, requestModel);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Update account successfully",
                    expertise);
            } catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            } catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{accountId:int}")]
        [SwaggerOperation(Summary = "Delete an account")]
        public async Task<IActionResult> Delete([FromRoute] int accountId)
        {
            try
            {
                var expertise = await _accountService.DeleteAsync(accountId);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Delete account successfully",
                    expertise);
            } catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            } catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
