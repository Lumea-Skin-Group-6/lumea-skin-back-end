using DAL.DTOs.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service;
using Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SkincareBookingApp.Controllers
{
    [ApiController]
    [Route("api/shifts")]
    [ApiExplorerSettings(GroupName = "Shifts")]
    public class ShiftsController : ODataController
    {
        private readonly IShiftService _shiftService;

        public ShiftsController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [EnableQuery]
        [HttpGet]
        [SwaggerOperation(Summary = "get all Shifts")]
        public IActionResult GetShifts()
        {
            var shift = _shiftService.GetAllShift();
            return Ok(shift);
        }

        [HttpPost("add-shift/{therapistShiftID}")]
        public IActionResult AddShift([FromRoute] int therapistShiftID,[FromBody] ShiftRequestDTO shiftRequest)
        {
            var response = _shiftService.AddShift(therapistShiftID, shiftRequest);

            return StatusCode(response.StatusCode, new
            {
                message = response.Title,
                data = response.Data
            });
        }


        [HttpPut("{shiftId}")]
        [SwaggerOperation(Summary = "update shift by id")]
        public IActionResult UpdateShift([FromRoute] int shiftId, [FromBody] ShiftRequestDTO shiftRequestDTO)
        {
            var response = _shiftService.UpdateAsync(shiftId, shiftRequestDTO);
            return StatusCode(response.StatusCode, new
            {
                message = response.Title,
                data = response.Data
            });
        }


        [EnableQuery]
        [HttpGet("{shiftId}")]
        [SwaggerOperation(Summary = "get shift by id")]
        public IActionResult GetShift([FromRoute] int shiftId)
        {
            var response = _shiftService.GetShiftById(shiftId);
            return StatusCode(response.StatusCode, new
            {
                message = response.Title,
                data = response.Data
            });
        }

        [HttpDelete("{shiftId}")]
        [SwaggerOperation(Summary = "delete shift by id")]
        public IActionResult DeleteShift([FromRoute] int shiftId)
        {
            var response = _shiftService.DeleteAsync(shiftId);
            return StatusCode(response.StatusCode, new
            {
                message = response.Title,
                data = response.Data
            });
        }

        [EnableQuery]
        [HttpGet("odata")]
        [SwaggerOperation(Summary = "get shifts by name")]
        public IActionResult GetShiftsByName([FromQuery] string name)
        {
            var shifts = _shiftService.GetAllShift()
                .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            return Ok(shifts);
        }

        [HttpGet("therapist/{therapistID}")]
        [SwaggerOperation(Summary = "get shifts by therapistId")]
        public IActionResult GetShiftByTherapistID([FromRoute] int therapistID)
        {
            var shifts = _shiftService.GetShiftsByTherapistId(therapistID);

            if (shifts == null || !shifts.Any())
            {
                return NotFound(new
                {
                    message = "There are no shifts belonging to this therapist."
                });
            }

            return Ok(shifts);
        }
    }
}