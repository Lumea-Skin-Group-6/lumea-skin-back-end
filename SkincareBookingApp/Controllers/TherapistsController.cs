using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service.Interfaces;
using Service.Services;
using SkincareBookingApp.Helpers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace SkincareBookingApp.Controllers
{
    [Route("api/therapists")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Therapists")]
    public class TherapistsController : ODataController
    {
        private readonly ITherapistService _therapistService;

        public TherapistsController(ITherapistService therapistService)
        {
            _therapistService = therapistService;
        }


        [EnableQuery]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all therapists")]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _therapistService.GetAllAsync();
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get therapists successfully",
                accounts);
        }

        [EnableQuery]
        [HttpGet("{accountId:int}")]
        [SwaggerOperation(Summary = "Get therapist by ID")]
        public async Task<IActionResult> GetExpertise([FromRoute] int accountId)
        {
            try
            {
                var account = await _therapistService.GetByIdAsync(accountId);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get therapist successfully",
                    account);
            } catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add a new therapist")]
        public async Task<IActionResult> Create([FromBody] AddTherapistRequestModel requestModel)
        {
            try
            {
                var account = await _therapistService.AddAsync(requestModel);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.Created, "Add therapist successfully",
                    account);
            } catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{accountId:int}")]
        [SwaggerOperation(Summary = "Update a therapist")]
        public async Task<IActionResult> Update([FromBody] UpdateTherapistRequestModel requestModel,
            [FromRoute] int accountId)
        {
            try
            {
                var expertise = await _therapistService.UpdateAsync(accountId, requestModel);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Update therapist successfully",
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
        [SwaggerOperation(Summary = "Delete a therapist")]
        public async Task<IActionResult> Delete([FromRoute] int accountId)
        {
            try
            {
                var expertise = await _therapistService.DeleteAsync(accountId);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Delete therapist successfully",
                    expertise);
            } catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            } catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("by-expertise")]
        public async Task<ActionResult<IEnumerable<TherapistResponseModel>>> GetAllTherapistsByExpertise([FromQuery] List<int> expertiseIds)
        {
            if (expertiseIds == null || !expertiseIds.Any())
            {
                return BadRequest("Expertise ID list cannot be empty.");
            }

            var therapists = await _therapistService.GetAllTherapistByListExpertiseID(expertiseIds);

            if (therapists == null || !therapists.Any())
            {
                return NotFound("No therapists found for the given expertise IDs.");
            }

            return Ok(therapists);
        }
    }
}
