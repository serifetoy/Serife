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

        [HttpPost]

        public IActionResult Add([FromBody] GroupDTO group)
        {
            var result = _groupManager.Add(group);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpPut]

        public IActionResult Update([FromBody] GroupDTO group)//? var zorunlu değil 
        {
            var result = _groupManager.Update(group);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpDelete]

        public IActionResult Delete(int groupId)
        {
            var result = _groupManager.Delete(groupId);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet]

        public IActionResult GetBy(int groupId)
        {
            var result = _groupManager.GetById(groupId);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }
    }
}
