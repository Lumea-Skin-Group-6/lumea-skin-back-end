using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Get all expertises")]
        public ActionResult<IEnumerable<ExpertiseResponseModel>> GetExpertises()
        {
            var expertises = _expertiseService.GetAll();
            return Ok(expertises.ToList());
        }

        [EnableQuery]
        [HttpGet("{expertiseId:int}")]
        [SwaggerOperation(Summary = "Get all expertise by ID")]
        public ActionResult<ExpertiseResponseModel> GetExpertise([FromRoute] int expertiseId)
        {
            var expertise = _expertiseService.GetById(expertiseId);
            if (expertise == null)
            {
                return NotFound();
            }
            return expertise;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add a new expertise")]
        public IActionResult Create([FromBody] AddExpertiseRequestModel addExpertiseDTO)
        {
            _expertiseService.Add(addExpertiseDTO);
            return Ok();
        }

        [HttpPut("{expertiseId:int}")]
        [SwaggerOperation(Summary = "Update an expertise")]
        public IActionResult Update([FromBody] UpdateExpertiseRequestModel updateExpertiseDTO, [FromRoute] int expertiseId)
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
        [SwaggerOperation(Summary = "Delete an expertise")]
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
