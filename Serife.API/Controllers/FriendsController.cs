using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serife.Business.Abstract;
using Serife.Business.Concrete;
using Serife.Common.DTOs;
using Serife.DataLayer.Entity;


namespace Serife.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        IFriendService _friendService;

        public FriendsController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpPost("Add")]

        public IActionResult Add([FromBody] FriendDTO dto)
        {
            var result = _friendService.Add(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return NotFound(result.Errors);
        }

        
        //[HttpPut("Update")]

        //public IActionResult Update(string friend )//?
        //{
        //    var result = FriendManager.Update(friend);
        //    if (result.Errors != null)
        //    {
        //        return NotFound(result.Errors);

        //    }
        //    return Ok(result.Value);
        //}


        //[HttpDelete("Delete")]

        //public IActionResult Delete([FromBody] FriendId friendId)
        //{
        //    var result = _friendService.Delete(friendId);
        //    if (result.Errors != null)
        //    {
        //        return NotFound(result.Value);

        //    }
        //    return NotFound(result.Errors);
        //}
        
     
        //[HttpGet("GetList")]

        //public IActionResult GetList([FromBody] int UserId)
        //{
        //    var result = FriendManager.GetList(UserId);
        //    if (result.Errors != null)
        //    {
        //        return NotFound(result.Errors);

        //    }
        //    return Ok(result.Value);//return olarak liste döndürülmeli yapamadım
        //}

    }


}
