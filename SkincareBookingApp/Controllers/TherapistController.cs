using DAL.DTOs.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace SkincareBookingApp.Controllers
{
    [Route("api/therapists")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Therapist")]
    public class TherapistController : ControllerBase
    {
        private readonly ITherapistService therapistService;

        public TherapistController(ITherapistService therapistService)
        {
            this.therapistService = therapistService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "add therapist")]
        public IActionResult AddTherapist([FromBody] TherapistRequest therapistRequest)
        {
            var therapist = therapistService.AddTherapist(therapistRequest);
            return StatusCode(therapist.StatusCode, new
            {
                message = therapist.Title,
                data = therapist.Data
            });
        }

        [HttpGet]
        [SwaggerOperation(Summary = "get all therapist")]
        public IActionResult GetAllTherapist()
        {
            var therapist = therapistService.GetAllTherapist();
            return StatusCode(therapist.StatusCode, new
            {
                message = therapist.Title,
                data = therapist.Data
            });
        }

        [HttpGet("{therapistID}")]
        [SwaggerOperation(Summary = "get therapist by id")]
        public IActionResult GetTherapistByID([FromRoute] int therapistID)
        {
            var therapist = therapistService.GetTherapistById(therapistID);
            return StatusCode(therapist.StatusCode, new
            {
                message = therapist.Title,
                data = therapist.Data
            });
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Udpate Therapist")]
        public IActionResult UpdateTherapist([FromBody] UpdateTherapistRequestModel therapistRequestModel)
        {
            var therapist = therapistService.UpdateTherapist(therapistRequestModel);
            return StatusCode(therapist.StatusCode, new
            {
                message = therapist.Title,
                data = therapist.Data
            });
        }

        [HttpDelete("{therapistID}")]
        [SwaggerOperation(Summary = "delete therapist by id")]
        public IActionResult DeleteTherapist([FromRoute] int therapistID)
        {
            var therapist = therapistService.DeleteTherapist(therapistID);
            return StatusCode(therapist.StatusCode, new
            {
                message = therapist.Title,
                data = therapist.Data
            });
        }
    }
}
