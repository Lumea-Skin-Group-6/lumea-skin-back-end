using DAL.DTOs.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service;
using SkincareBookingApp.Helpers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace SkincareBookingApp.Controllers
{
    [Route("api/services")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Services")]
    public class ServicesController : ODataController
    {
        private readonly IServiceService _serviceService;
        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [EnableQuery]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all services")]
        public async Task<IActionResult> GetServices()
        {
            var services = await _serviceService.GetAllAsync();
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get services successfully",
            services);
        }

        [EnableQuery]
        [HttpGet("{serviceId:int}")]
        [SwaggerOperation(Summary = "Get all service by ID")]
        public async Task<IActionResult> GetService([FromRoute] int serviceId)
        {
            try
            {
                var service = await _serviceService.GetByIdAsync(serviceId);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get expertise successfully",
                service);
            } catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add a new service")]
        public async Task<IActionResult> Create([FromBody] AddServiceRequestModel requestModel)
        {
            try
            {
                var service = await _serviceService.AddAsync(requestModel);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.Created, "Add service successfully",
                service);
            } catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{serviceId:int}")]
        [SwaggerOperation(Summary = "Update a service")]
        public async Task<IActionResult> Update([FromBody] UpdateServiceRequestModel requestModel, [FromRoute] int serviceId)
        {
            try
            {
                var service = await _serviceService.UpdateAsync(serviceId, requestModel);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Update service successfully",
                service);
            } catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            } catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{serviceId:int}")]
        [SwaggerOperation(Summary = "Delete a service")]
        public async Task<IActionResult> Delete([FromRoute] int serviceId)
        {
            try
            {
                var service = await _serviceService.DeleteAsync(serviceId);
                return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Delete service successfully",
                service);
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
