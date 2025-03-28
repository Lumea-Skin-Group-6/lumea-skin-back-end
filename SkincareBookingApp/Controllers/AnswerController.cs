using BusinessObject;
using DAL.DTOs.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using SkincareBookingApp.Helpers;
using System.Net;

namespace SkincareBookingApp.Controllers
{
    [Route("api/answers")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Answers")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAnswers()
        {
            var answers = await _answerService.GetAllAnswersAsync();
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get all answers successfully", answers);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswerById(int id)
        {
            var answer = await _answerService.GetAnswerByIdAsync(id);
            if (answer == null) return NotFound();
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get answer successfully", answer);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAnswer([FromBody] AnswerCreateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var answer = await _answerService.AddAnswerAsync(request);
            if (answer == null) return BadRequest("Add failed");
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Add answer successfully", answer);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, [FromBody] AnswerUpdateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != request.Id) return BadRequest("Answer ID mismatch");
            var answer = await _answerService.UpdateAnswerAsync(request);
            if (answer == null) return BadRequest("Updated failed");
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Update answer successfully", answer);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _answerService.DeleteAnswerAsync(id);
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Delete answer successfully", null);
        }
    }
}
