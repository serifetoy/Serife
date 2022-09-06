using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serife.Business.Abstract;
using Serife.Business.Concrete;
using Serife.Common.DTOs;

namespace Serife.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        GroupManager _groupManager;

        public GroupsController(GroupManager groupManager)
        {
            _groupManager = groupManager;
        }

        [HttpPost("Group/add/{group}")]

        public IActionResult Add([FromBody] GroupDTO group)
        {
            var result = _groupManager.Add(group);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpPut("Group/update/{group}")]

        public IActionResult Update([FromBody] GroupDTO group)//? var zorunlu değil 
        {
            var result = _groupManager.Update(group);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpDelete("Group/delete/{groupID}")]

        public IActionResult Delete(int groupId)
        {
            var result = _groupManager.Delete(groupId);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("Group/{groupID}")]

        public IActionResult GetBy(int groupId)
        {
            var result = _groupManager.GetBy(groupId);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }
    }
}
