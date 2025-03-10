using BusinessObject;
using DAL.DTOs.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using SkincareBookingApp.Helpers;
using System.Net;

namespace SkincareBookingApp.Controllers
{
    [ApiController]
    [Route("api/questions")]
    [ApiExplorerSettings(GroupName = "Questions")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionService.GetAllQuestionAsync();
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get all questions successfully", questions);
        }

        [HttpGet("with-answers")]
        public async Task<IActionResult> GetAllQuestionsWithAnswers()
        {
            var questions = await _questionService.GetAllQuestionsWithAnswersAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound(new { message = "Question not found." });
            }
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get question successfully", question);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionCreateRequest request)
        {
            var result = await _questionService.AddQuestionAsync(request);
            return result != null
                ? CustomSuccessHandler.ResponseBuilder(HttpStatusCode.Created, "Question added successfully.", result)
                : BadRequest(new { message = "Failed to add question." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] QuestionUpdateRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest(new { message = "Question ID mismatch." });
            }

            var result = await _questionService.UpdateQuestionAsync(request);
            return result != null
                ? CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Question updated successfully.", result)
                : NotFound(new { message = "Question not found." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionService.DeleteQuestionAsync(id);
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Question deleted successfully.", null);
        }
    }

}
