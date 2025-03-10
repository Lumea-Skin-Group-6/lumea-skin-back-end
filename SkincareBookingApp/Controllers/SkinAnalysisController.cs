using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using SkincareBookingApp.Helpers;
using System.Net;

namespace SkincareBookingApp.Controllers
{
    [Route("api/skin-analysis")]
    [ApiController]
    public class SkinAnalysisController : ControllerBase
    {
        private readonly ISkinAnalysisService _skinAnalysisService;

        public SkinAnalysisController(ISkinAnalysisService skinAnalysisService)
        {
            _skinAnalysisService = skinAnalysisService;
        }

        [HttpPost("analyze")]
        public async Task<IActionResult> AnalyzeSkin([FromBody] List<int> answerIds)
        {
            if (answerIds == null || !answerIds.Any())
            {
                return BadRequest(new { message = "No answers provided." });
            }

            var result = await _skinAnalysisService.AnalyzeSkinTypeAsync(answerIds);
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Analysis done!", result);
        }
    }
}
