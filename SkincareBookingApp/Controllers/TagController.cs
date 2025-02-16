using BusinessObject;
using DAL.DTOs.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using SkincareBookingApp.Helpers;
using System.Net;

namespace SkincareBookingApp.Controllers
{
    [Route("api/tags")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Tags")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _tagService.GetAllTagsAsync();
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get all tags successfully", tags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);
            if (tag == null) return NotFound();
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Get tag successfully", tag);
        }

        [HttpPost]
        public async Task<IActionResult> AddTag([FromBody] TagCreateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _tagService.AddTagAsync(request);
            return CreatedAtAction(nameof(GetTagById), new { id = request.name }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, [FromBody] TagUpdateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != request.tag_id) return BadRequest("Tag ID mismatch");

            await _tagService.UpdateTagAsync(request);
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Update tag successfully", null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _tagService.DeleteTagAsync(id);
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Delete tag successfully", null);
        }
    }
}
