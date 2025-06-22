using AutoMapper;
using MoveIt.Core.Resources;
using MoveIt.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoveIt.Service;
using MoveIt.Core.Models;

namespace MoveIt.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet("available/{memberId}")]
        public IActionResult GetAvailableClasses(int memberId)
        {
            var classes = _classService.GetAvailableClassesForMember(memberId);
            return Ok(classes);
        }
    }


}
