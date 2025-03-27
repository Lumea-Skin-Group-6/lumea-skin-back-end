using DAL.DTOs.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SkincareBookingApp.Controllers
{

    [ApiController]
    [Route("api/TherapistShift")]
    [ApiExplorerSettings(GroupName = "TherapistShift")]
    public class TherapistShiftController : Controller
    {
        private readonly IShiftService _shiftService;

        public TherapistShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "get all TherapistShift")]
        public IActionResult GetAllTherapistShift()
        {
            var therapistShift = _shiftService.GetAllTherapistShift();
            return Ok(therapistShift);
        }

        [HttpPost("add-therapistshift/{therapistID}/{shiftID}")]
        [SwaggerOperation(Summary = "Therapist Regis Date to word")]
        public IActionResult AddTherapistShift([FromRoute] int therapistID, [FromRoute]int shiftID, [FromBody] TherapistShiftDateRequest dateTime)
        {
            var therapistShift = _shiftService.AddTherapistShift(therapistID, shiftID, dateTime);
            return Ok(therapistShift);
        }

        [HttpPut("update-therapistshift/{therapistID}/{therapistShiftID}")]
        [SwaggerOperation(Summary = "Therapist update Date to word")]
        public IActionResult Update([FromRoute] int therapistID, [FromRoute] int therapistShiftID, [FromQuery] DateTime dateTime)
        {
            var therapistShift = _shiftService.UpdateTherapistShift(therapistID, therapistShiftID, dateTime);
            return Ok(therapistShift);
        }

        [HttpDelete("delte-therapstshift/{therapistshiftID}")]
        [SwaggerOperation(Summary = "delete")]
        public IActionResult Delete([FromRoute] int therapistshiftID)
        {
            var therapistShift = _shiftService.DeleteTherapistShift(therapistshiftID);
            return Ok(therapistShift);
        }
    }
}
