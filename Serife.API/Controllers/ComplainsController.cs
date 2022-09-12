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
       
        ComplainManager _complainManager;
        

        public ComplainsController(ComplainManager complainManager)
        {
            _complainManager = complainManager;
        }


        [HttpPost]

        public IActionResult Add([FromBody] ComplainDTO dto)
        {
            var result = _complainManager.Add(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return Ok(result.Errors);
        }


        
        [HttpPut]

        public IActionResult Update([FromBody] ComplainDTO dto)
        {
            var result = _complainManager.Update(dto);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return Ok(result.Errors);
        }

       
        [HttpDelete]

        public IActionResult Delete([FromBody] int userid)
        {
            var result = _complainManager.Delete(userid);
            if (result.Errors != null)
            {
                return NotFound(result.Value);

            }
            return Ok(result.Errors);
        }

        [HttpGet("user/{userID}/Complain")]

        public IActionResult GetComplainByUserId(int userId)
        {
            var result = _complainManager.GetComplainByUserId(userId);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        } //liste döndürme hatası, complainmanager BCResponse yapılmalı fonksiyon değiştirilmeli

        [HttpGet("Complain/{complainID}")]

        public IActionResult GetById(int complainId)//bu en son kaldırdığım comentten, urller farklı
        {
            var result = _complainManager.GetById(complainId);
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

        [HttpGet]//BURDA NEDEN URL YOK??

        public IActionResult GetListAll()
        {
            var result = _complainManager.GetListAll();
            if (result.Errors != null)
            {
                return NotFound(result.Errors);

            }
            return Ok(result.Value);
        }

    }
}
