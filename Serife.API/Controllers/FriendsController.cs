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

        FriendManager _friendManager;

        public FriendsController(FriendManager friendManager)
        {
            _friendManager = friendManager;
        }

      

        [HttpPost]

        public IActionResult Add([FromBody] FriendDTO dto)
        {
            var result = _friendManager.Add(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return NotFound(result.Errors);
        }


        [HttpPut]

        public IActionResult Update(FriendDTO friend)//DTO İLE Mİ ALINCAK TEYİT ET
        {
            var result = _friendManager.Update(friend);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }


        [HttpDelete]

        public IActionResult Delete([FromBody] int friendId)//İNTEGER MI DTO MU KONTROL ET
        {
            var result = _friendManager.Delete(friendId);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return NotFound(result.Errors);
        }


        [HttpGet]

        public IActionResult GetList( int UserId)
        {
            var result = _friendManager.GetList(UserId);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);//return olarak liste döndürülmeli yapamadım
        }

    }


}
