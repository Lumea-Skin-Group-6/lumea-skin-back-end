using BusinessObject;
using DAL.DTO.Shift;
using DAL.DTO.ShiftDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Service;

namespace SkincareBookingApp.Controllers
{
    [ApiController]
    [Route("api/shift")]
    public class ShiftController : ControllerBase
    {

        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [EnableQuery]
        [HttpGet("get-all-shift")]
        public IActionResult GetShifts()
        {
            var shift = _shiftService.GetAllShift();
            return Ok(shift);
        }


        [HttpPost("add-shift")]
        public IActionResult AddShift([FromBody]ShiftRequestDTO shiftRequest)
        {
            var response = _shiftService.AddShift(shiftRequest);

            return StatusCode(response.StatusCode, new
            {
                message = response.Message,
                data = response.Data
            });
        }

        [HttpPut("update-shift/{shiftId}")]
        public IActionResult UpdateShift([FromRoute]int  shiftId, [FromBody]ShiftRequestDTO shiftRequestDTO) 
        {
            var response = _shiftService.UpdateAsync(shiftId, shiftRequestDTO);
            return StatusCode(response.StatusCode, new
            {
                message = response.Message,
                data = response.Data
            });
        }

        [HttpGet("get-by-/{shiftId}")]
        public IActionResult UpdateShift([FromRoute] int shiftId)
        {
            var response = _shiftService.GetShiftById(shiftId);
            return StatusCode(response.StatusCode, new
            {
                message = response.Message,
                data = response.Data
            });
        }

        [HttpDelete("delete-by-/{shiftId}")]
        public IActionResult DeleteShift([FromRoute] int shiftId)
        {
            var response = _shiftService.DeleteAsync(shiftId);
            return StatusCode(response.StatusCode, new
            {
                message = response.Message,
                data = response.Data
            });
        }
    }
}
