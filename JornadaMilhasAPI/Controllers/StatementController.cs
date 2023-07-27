using JornadaMilhasAPI.Models;
using JornadaMilhasAPI.Repositories.Testimony;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JornadaMilhasAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class StatementController : Controller
    {
        private readonly ITestimonyRepository _testimony;
        public StatementController(ITestimonyRepository testimony)
        {
            _testimony = testimony;
        }

        [HttpGet("depoimentos/{id}")]
        public IActionResult Get(int id)
        {
            try {

                var testimony = _testimony.get(id);
                if(testimony is null)
                {
                    return NotFound();
                }
                return Ok(testimony);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }

        [HttpGet("depoimentos-home")]

        public IActionResult GetHome()
        {
            try
            {
                var testimonies = _testimony.getHome();
                if (!testimonies.Any())
                {
                    return NoContent();
                }
                return Ok(testimonies);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }
        [HttpDelete("depoimentos/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var testimony = _testimony.get(id);
                if (testimony is null)
                {
                    return NotFound();
                }
                _testimony.delete(id);
                return StatusCode(200, new { status = 200, message = "Depoimento deletado com sucesso" });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }
        [HttpPut("depoimentos")]
        public IActionResult Update([FromBody] TestimonyModel testimony)
        {
            try
            {
                var testimonyGet = _testimony.get(testimony.Id);
                if (testimonyGet is null)
                {
                    return NotFound();
                }
                _testimony.update(testimony);
                return StatusCode(201, new { status = 201, message = "Depoimento atualizado com sucesso" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }
        [HttpPost("depoimentos")]
        public IActionResult Insert([FromBody] TestimonyModel testemony)
        {
            try
            {
                var inserted = _testimony.insert(testemony);
                if(!inserted)
                {
                    return BadRequest();
                }
                return StatusCode(201, new { status = 201, message = "Depoimento adicionado com sucesso"});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }
    }
}
