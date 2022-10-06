using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serife.Business.Abstract;
using Serife.Business.Concrete;
using Serife.Common.DTOs;
using Serife.Common.Result;
using Serife.DataLayer.Entity;

namespace Serife.API.Controllers
{
    [Route("user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
    
        UserManager _userManager;

        public UsersController(UserManager userManager)
        {
            _userManager = userManager;
        }


        [HttpPost("Add")]

        public IActionResult Add([FromBody] UserDTO user)
        {
            var result = _userManager.Add(user);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpPut("Update")]

        public IActionResult Update([FromBody] UserDTO user)//? var zorunlu değil 
        {
            var result = _userManager.Update(user);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpDelete("Delete")]

        public IActionResult Delete(int userid)
        {
            var result = _userManager.Delete(userid);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("GetById/{userId}")]

        public IActionResult GetById(int userId)
        {
            var result = _userManager.GetById(userId);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("GetByUserName/{userName}")]

        public IActionResult GetByUserName(string userName)
        {
            var result = _userManager.GetByUserName(userName);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [Route("/Users/GetUsers")]
        [HttpGet]

        public IActionResult GetUsers( )
        {
            var result = _userManager.GetUsers();
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }


    }
}
