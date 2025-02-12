using DAL.DTO.Expertise;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace SkincareBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertiseController : ControllerBase
    {
        private readonly IExpertiseService _expertiseService;
        public ExpertiseController(IExpertiseService expertiseService)
        {
            _expertiseService = expertiseService;
        }

        [HttpGet]
        public ActionResult<List<ExpertiseDTO>> GetAll()
        {
            var expertises = _expertiseService.GetAll();
            return Ok(expertises);
        }

        [HttpGet("{expertiseId:int}")]
        public ActionResult<ExpertiseDTO> GetById([FromRoute] int expertiseId)
        {
            var expertise = _expertiseService.GetById(expertiseId);
            if (expertise == null)
            {
                return NotFound();
            }
            return Ok(expertise);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddExpertiseDTO addExpertiseDTO)
        {
            _expertiseService.Add(addExpertiseDTO);
            return Ok();
        }

        [HttpPut("{expertiseId:int}")]
        public IActionResult Update([FromBody] UpdateExpertiseDTO updateExpertiseDTO, [FromRoute] int expertiseId)
        {
            var expertise = _expertiseService.GetById(expertiseId);
            if (expertise == null)
            {
                return NotFound();
            }
            _expertiseService.Update(expertiseId, updateExpertiseDTO);
            return Ok();
        }

        [HttpDelete("{expertiseId:int}")]
        public IActionResult Delete([FromRoute] int expertiseId)
        {
             var expertise = _expertiseService.GetById(expertiseId);
            if (expertise == null)
            {
                return NotFound();
            }
            _expertiseService.Delete(expertiseId);
            return Ok();
        }
    }
}
