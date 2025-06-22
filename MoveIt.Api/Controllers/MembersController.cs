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
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _MembersService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public MembersController(IMemberService MembersService, IMapper mapper, ILogger<MembersController> logger)
        {
            _mapper = mapper;
            _MembersService = MembersService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberResource>> GetById(int id)
        {
            var Member = await _MembersService.GetMemberById(id);
            return Ok(_mapper.Map<MemberResource>(Member));
        }


        [HttpPost]
        public async Task<ActionResult<int>> AddMember([FromBody] MemberResource memberResource)
        {
            // המרת ה-DTO למודל
            var member = _mapper.Map<Members>(memberResource);

            // הוספת ה-member
            var result = await _MembersService.AddMember(member);

            if (result == 0)
            {
                _logger.LogWarning("AddMember failed for member: {@Member}", member);
                return BadRequest("Failed to add member");
            }

            return Ok(result); // מחזיר כמה שורות הושפעו (למשל 1 אם הצליח)
        }

    }


}
