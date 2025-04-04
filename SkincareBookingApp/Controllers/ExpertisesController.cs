﻿using DAL.DTOs.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service;
using SkincareBookingApp.Helpers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace SkincareBookingApp.Controllers
{
    [Route("api/expertises")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Expertises")]
    public class ExpertisesController : ODataController
    {
        private readonly IExpertiseService _expertiseService;

        public ExpertisesController(IExpertiseService expertiseService)
        {
            _expertiseService = expertiseService;
        }

        [EnableQuery]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all expertises")]
        public async Task<IActionResult> GetExpertises()
        {
            var expertises = await _expertiseService.GetAllAsync();
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get expertises successfully",
                expertises);
        }

        [EnableQuery]
        [HttpGet("{expertiseId:int}")]
        [SwaggerOperation(Summary = "Get expertise by ID")]
        public async Task<IActionResult> GetExpertise([FromRoute] int expertiseId)
        {
            try
            {
                var expertise = await _expertiseService.GetByIdAsync(expertiseId);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get expertise successfully",
                    expertise);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add a new expertise")]
        public async Task<IActionResult> Create([FromBody] AddExpertiseRequestModel requestModel)
        {
            try
            {
                var expertise = await _expertiseService.AddAsync(requestModel);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.Created, "Add expertise successfully",
                    expertise);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{expertiseId:int}")]
        [SwaggerOperation(Summary = "Update an expertise")]
        public async Task<IActionResult> Update([FromBody] UpdateExpertiseRequestModel requestModel,
            [FromRoute] int expertiseId)
        {
            try
            {
                var expertise = await _expertiseService.UpdateAsync(expertiseId, requestModel);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Update expertise successfully",
                    expertise);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{expertiseId:int}")]
        [SwaggerOperation(Summary = "Delete an expertise")]
        public async Task<IActionResult> Delete([FromRoute] int expertiseId)
        {
            try
            {
                var expertise = await _expertiseService.DeleteAsync(expertiseId);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Delete expertise successfully",
                    expertise);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}