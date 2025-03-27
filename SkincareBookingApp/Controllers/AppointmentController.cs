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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDTO appointmentDTO)
        {
            var result = await _appointmentService.CreateAppointmentAsync(appointmentDTO);
            return result != null
                ? CustomSuccessHandler.ResponseBuilder(HttpStatusCode.Created, "Appointment added successfully.", result)
                : BadRequest(new { message = "Failed to add appointment." });
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] UpdateAppointmentDTO appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest(new { message = "Appointment ID mismatch." });
            }

            var updatedAppointment = await _appointmentService.UpdateAppointmentAsync(appointment);
            return updatedAppointment != null
                ? CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Appointment updated successfully.", updatedAppointment)
                : NotFound(new { message = "Appointment not found." });
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            return appointment != null
                ? CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "get Appointment successfully.", appointment)
                : NotFound(new { message = "Appointment not found." });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "get Appointment list successfully.", appointments);
        }
    }

}
