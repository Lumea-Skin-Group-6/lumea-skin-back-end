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
    }
}
