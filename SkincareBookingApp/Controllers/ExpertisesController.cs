using BusinessObject;
using DAL.DTO.Expertise;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service;

namespace SkincareBookingApp.Controllers
{
    [Route("api/expertises")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Expertises")]
    public class ExpertisesController : ODataController
    {
        private readonly IExpertiseService _expertiseService;
        public ExpertisesController(IExpertiseService expertiseService)
        {
            _expertiseService = expertiseService;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<ExpertiseDTO>> GetExpertises()
        {
            var expertises = _expertiseService.GetAll();
            return Ok(expertises.ToList());
        }

        [EnableQuery]
        [HttpGet("{expertiseId:int}")]
        public ActionResult<ExpertiseDTO> GetExpertise([FromRoute] int expertiseId)
        {
            var expertise = _expertiseService.GetById(expertiseId);
            if (expertise == null)
            {
                return NotFound();
            }
            return expertise;
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
