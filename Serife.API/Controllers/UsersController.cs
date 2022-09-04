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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
    
        UserManager _userManager;

        public UsersController(UserManager userManager)
        {
            _userManager = userManager;
        }


        [HttpPost("User/{user}")]

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

        [HttpDelete("User/{userID}")]

        public IActionResult Delete(int userid)
        {
            var result = _userManager.Delete(userid);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("{userID}")]

        public IActionResult GetById(int userID)
        {
             User? user  = _userManager.GetById(userID);
            if (user.Errors != null)
            {
                return NotFound(user.Errors);

            }
            return Ok(user.Value);
        }
    }
}
