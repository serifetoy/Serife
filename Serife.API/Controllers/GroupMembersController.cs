using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serife.Business.Abstract;

namespace Serife.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMembersController : ControllerBase
    {
        IGroupMemberService _groupMemberService;

        public GroupMembersController(IGroupMemberService groupMemberService)
        {
            _groupMemberService = groupMemberService;
        }
    }
}
