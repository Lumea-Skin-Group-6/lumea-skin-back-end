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

        [HttpGet("free/{therapistId}")]
        public async Task<IActionResult> GetFreeSlots([FromRoute]int therapistId)
        {
            var slots = await _slotService.GetFreeSlotsOfTherapist(therapistId);
            if (slots == null || slots.Count == 0)
            {
                return NotFound("No free slots available for this therapist.");
            }
            return Ok(slots);
        }
    }
}
