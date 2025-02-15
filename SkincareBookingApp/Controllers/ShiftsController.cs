using BusinessObject;
using DAL.DTO.Shift;
using DAL.DTO.ShiftDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Routing;
using Service;

namespace SkincareBookingApp.Controllers
{
    [ApiController]
    [Route("api/shift")]
    public class ShiftsController : ODataController
    {

        private readonly IShiftService _shiftService;

        public ShiftsController(IShiftService shiftService)
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


        [EnableQuery]
        [HttpGet("get-by-/{shiftId}")]
        public IActionResult GetShift([FromRoute] int shiftId)
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

        [EnableQuery]
        [HttpGet("odata/get-by-name")]
        public IActionResult GetShiftsByName([FromQuery] string name)
        {
            var shifts = _shiftService.GetAllShift()
                                      .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            return Ok(shifts);
        }

    }
}
