using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serife.Business.Abstract;
using Serife.Business.Concrete;
using Serife.Common.DTOs;

namespace Serife.API.Controllers
{
    [Route("Complain")]
    [ApiController]
    public class ComplainsController : ControllerBase
    {
        ComplainManager _complainManager;

        public ComplainsController(ComplainManager complainManager)
        {
            _complainManager = complainManager;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] ComplainDTO dto)
        {
            var result = _complainManager.Add(dto);
            if (result.Errors == null)
            {
                return Ok(result.Value);


            }
            return NotFound(result.Errors);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _complainManager.Delete(id);
            if (result.Errors == null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] ComplainDTO dto)
        {
            var result = _complainManager.Update(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _complainManager.GetById(id);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }


        [HttpGet("GetListAll")]
        public IActionResult GetListAll()
        {
            var result = _complainManager.GetListAll();
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet("getcomplainbyuserıd/{id}")]
        public IActionResult GetComplainByUserID(int id)
        {
            var result = _complainManager.GetComplainByUserId(id);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }
    }
}
