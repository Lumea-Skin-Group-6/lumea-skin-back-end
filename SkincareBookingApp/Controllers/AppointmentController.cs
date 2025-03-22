using DAL.DTOs.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using SkincareBookingApp.Helpers;
using System.Net;

namespace SkincareBookingApp.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDTO appointmentDTO)
        {
            var result = await _appointmentService.CreateAppointmentAsync(appointmentDTO);
            return result != null
                ? CustomSuccessHandler.ResponseBuilder(HttpStatusCode.Created, "Appointment added successfully.", result)
                : BadRequest(new { message = "Failed to add appointment." });
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAppointmentById(int id)
        //{
        //    var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
        //    if (appointment == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(appointment);
        //}

        //[HttpGet("account/{accountId}")]
        //public async Task<IActionResult> GetAppointmentsByAccount(int accountId)
        //{
        //    var appointments = await _appointmentService.GetAppointmentsByAccountIdAsync(accountId);
        //    return Ok(appointments);
        //}
    }

}
