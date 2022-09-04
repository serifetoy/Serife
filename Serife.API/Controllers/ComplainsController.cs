using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serife.Business.Abstract;
using Serife.Business.Concrete;
using Serife.Common.DTOs;

namespace Serife.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplainsController : ControllerBase
    {
        IComplainService _complainService;
        public ComplainsController(IComplainService complainService)
        {
            _complainService = complainService;
        }


        [HttpPost("Add")]

        public IActionResult Add([FromBody] ComplainDTO dto)
        {
            var result = _complainService.Add(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return Ok(result.Errors);
        }


        
        [HttpPut("Update")]

        public IActionResult Update([FromBody] ComplainDTO dto)
        {
            var result = _complainService.Update(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return NotFound(result.Errors);
        }

       
        [HttpDelete("Delete")]

        public IActionResult Delete([FromBody] int userid)
        {
            var result = _complainService.Delete(userid);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return NotFound(result.Errors);
        }


    }
}
