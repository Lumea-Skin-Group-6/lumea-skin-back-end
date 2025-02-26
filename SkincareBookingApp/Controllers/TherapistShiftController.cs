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

        [HttpPost("add-therapistshift/{therapistID}")]
        [SwaggerOperation(Summary = "Therapist Regis Date to word")]
        public IActionResult AddTherapistShift([FromRoute] int therapistID, [FromQuery]DateTime dateTime)
        {
            var therapistShift = _shiftService.AddTherapistShift(therapistID, dateTime);
            return Ok(therapistShift);
        }
    }
}
