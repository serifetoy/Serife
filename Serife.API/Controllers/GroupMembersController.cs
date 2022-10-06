using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serife.Business.Abstract;
using Serife.Business.Concrete;
using Serife.Common.DTOs;

namespace Serife.API.Controllers
{
    [Route("GroupMember")]
    [ApiController]
    public class GroupMembersController : ControllerBase
    {
        GroupMemberManager _groupMemberManager;

        public GroupMembersController(GroupMemberManager groupMemberManager)
        {
            _groupMemberManager = groupMemberManager;
        }

        [HttpPost]
        public IActionResult Add([FromBody] GroupMemberDTO groupMember)
        {
            var result = _groupMemberManager.Add(groupMember);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpPut]
        public IActionResult Update([FromBody] GroupMemberDTO groupMember)
        {
            var result = _groupMemberManager.Update(groupMember);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }
        [HttpDelete]
        public IActionResult Delete(int groupId)
        {
            var result = _groupMemberManager.Delete(groupId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("GetById/{groupId}")]
        public IActionResult GetById(int groupId)
        {
            var result = _groupMemberManager.GetById(groupId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }
    }
}
