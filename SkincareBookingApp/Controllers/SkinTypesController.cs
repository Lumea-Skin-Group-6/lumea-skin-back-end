using DAL.DTOs.RequestModel;
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
    [Route("api/skin-types")]
    [ApiExplorerSettings(GroupName = "Skin types")]
    [ApiController]
    public class SkinTypesController : ODataController
    {
        private readonly ISkinTypeService _skinTypeService;
        public SkinTypesController(ISkinTypeService skinTypeService)
        {
            _skinTypeService = skinTypeService;
        }

        [EnableQuery]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all skin types")]
        public async Task<IActionResult> GetSkinTypes()
        {
            var skinTypes = await _skinTypeService.GetAllAsync();
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get skin types successfully",
                skinTypes);
        }

        [EnableQuery]
        [HttpGet("{skinTypeId:int}")]
        [SwaggerOperation(Summary = "Get skin type by ID")]
        public async Task<IActionResult> GetSkinType([FromRoute] int skinTypeId)
        {
            try
            {
                var skinType = await _skinTypeService.GetByIdAsync(skinTypeId);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get skin type successfully",
                    skinType);
            } catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add a new skin type")]
        public async Task<IActionResult> Create([FromBody] AddSkinTypeRequestModel requestModel)
        {
            try
            {
                var skinType = await _skinTypeService.AddAsync(requestModel);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.Created, "Add skin type successfully",
                    skinType);
            } catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{skinTypeId:int}")]
        [SwaggerOperation(Summary = "Update a skin type")]
        public async Task<IActionResult> Update([FromBody] UpdateSkinTypeRequestModel requestModel,
            [FromRoute] int skinTypeId)
        {
            try
            {
                var skinType = await _skinTypeService.UpdateAsync(skinTypeId, requestModel);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Update skin type successfully",
                    skinType);
            } catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            } catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{skinTypeId:int}")]
        [SwaggerOperation(Summary = "Delete a skin type")]
        public async Task<IActionResult> Delete([FromRoute] int skinTypeId)
        {
            try
            {
                var skinType = await _skinTypeService.DeleteAsync(skinTypeId);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Delete skin type successfully",
                    skinType);
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
