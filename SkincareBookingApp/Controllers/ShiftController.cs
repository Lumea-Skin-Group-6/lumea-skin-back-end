using BusinessObject;
using DAL.DTO.Shift;
using DAL.DTO.ShiftDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Service;

namespace SkincareBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftController : ControllerBase
    {

        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [EnableQuery]
        [HttpGet(Name = "get-all-shift")]
        public IActionResult GetShifts()
        {
            var shift = _shiftService.GetAllShift();
            return Ok(shift);
        }


        [HttpPost(Name = "add-shift")]
        public IActionResult AddShift([FromBody]ShiftRequestDTO shiftRequest)
        {
            var response = _shiftService.AddShift(shiftRequest);

            return StatusCode(response.StatusCode, response.Data); // Trả về HTTP status code và dữ liệu
        }

    }
}
