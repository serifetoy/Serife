using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serife.Business.Abstract;

namespace Serife.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }
    }
}
