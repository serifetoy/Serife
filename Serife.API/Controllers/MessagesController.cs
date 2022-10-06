using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serife.Business.Abstract;
using Serife.Business.Concrete;
using Serife.Common.DTOs;

namespace Serife.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        MessageManager _messageManager;

        public MessagesController(MessageManager messageManager)
        {
            _messageManager = messageManager;
        }


        [HttpPost]

        public IActionResult SendMessage([FromBody] MessageDTO message)
        {
            var result = _messageManager.SendMessage(message);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }


        [HttpDelete]

        public IActionResult Delete(int messageId)
        {
            var result = _messageManager.Delete(messageId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("user/{senderId}/groupchat/{receiverId}/Message")]
        public IActionResult GetPrivateMessage(int senderId, int receiverId)
        {
            var result = _messageManager.GetPrivateMessage(senderId, receiverId);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);

        }
        [HttpGet("user/{senderId}/groupchat/{groupId}")] //URL BAK
        public IActionResult GetGroupMessage(int senderId, int groupId)
        {
            var result = _messageManager.GetGroupMessage(senderId, groupId);
            
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);

        }


    }
}
