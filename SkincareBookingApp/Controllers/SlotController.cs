using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace SkincareBookingApp.Controllers
{
    [ApiController]
    [Route("api/slots")]
    [ApiExplorerSettings(GroupName = "Slots")]
    public class SlotController : Controller
    {
        private readonly ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpGet("free/{employeeID}")]
        public async Task<IActionResult> GetFreeSlots([FromRoute]int employeeID)
        {
            var slots = await _slotService.GetFreeSlotsOfTherapist(employeeID);
            if (slots == null || slots.Count == 0)
            {
                return NotFound("No free slots available for this therapist.");
            }
            return Ok(slots);
        }


        //[Authorize(Roles = "Therapist, Manager")]
        [HttpGet("generateShifts")]
        public async Task<IActionResult> GenerateShifts([FromQuery] string shiftName, [FromQuery] DateTime dateTime)
        {
            var shift = await _slotService.GenerateShifts(shiftName, dateTime);
            if (shift == null || shift.Count == 0)
            {
                return NotFound("No free shifts available for this therapist.");
            }
            return Ok(shift);
        }
    }
}
