using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Service.Interfaces;
using Service.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace SkincareBookingApp.Controllers
{
    [Route("api/roles")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "get all Roles")]
        public IActionResult GetAllRole()
        {
            var role = roleService.GetAllRole();
            return Ok(role);
        }
    }
}
