using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SkincareBookingApp.Controllers
{

    [ApiController]
    [Route("api/TherapistShift")]
    [ApiExplorerSettings(GroupName = "TherapistShift")]
    public class TherapistShiftsController : ODataController
    {
        private readonly IShiftService _shiftService;

        public TherapistShiftsController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet("grouped")]
        [SwaggerOperation(Summary = "Get all TherapistShift Grouped by date")]
        public IActionResult GetAllTherapistShift()
        {
            var therapistShift = _shiftService.GetAllTherapistShift();
            return Ok(therapistShift);
        }

        [EnableQuery]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all TherapistShift")]
        public async Task<ActionResult<IEnumerable<TherapistShiftResponse>>> GetTherapistShifts()
        {
            var therapistShift = await _shiftService.GetTherapistShifts();
            return Ok(therapistShift);
        }

        [HttpPost("{therapistID}")]
        [SwaggerOperation(Summary = "Therapist Regis Date to work")]
        public IActionResult AddTherapistShift([FromRoute] int therapistID, [FromBody] TherapistShiftDateRequest request)
        {
            var therapistShift = _shiftService.AddTherapistShift(therapistID, request);
            return Ok(therapistShift);
        }

        [HttpPut("{therapistID}")]
        [SwaggerOperation(Summary = "Therapist update Date to work")]
        public IActionResult Update([FromRoute] int therapistID, [FromRoute] int therapistShiftID, [FromQuery] DateTime dateTime)
        {
            var therapistShift = _shiftService.UpdateTherapistShift(therapistID, therapistShiftID, dateTime);
            return Ok(therapistShift);
        }

        [HttpDelete("{therapistshiftID}")]
        [SwaggerOperation(Summary = "delete")]
        public IActionResult Delete([FromRoute] int therapistshiftID)
        {
            var therapistShift = _shiftService.DeleteTherapistShift(therapistshiftID);
            return Ok(therapistShift);
        }
    }
}
