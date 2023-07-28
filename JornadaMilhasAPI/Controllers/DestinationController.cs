using JornadaMilhasAPI.Models;
using JornadaMilhasAPI.Repositories.Destination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationRepository _repository;
        public DestinationController(IDestinationRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _repository.GetAll();
                if (!result.Any())
                {
                    return NoContent();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Problem();
            }
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            try
            {
                var result = _repository.DeleteById(id);
                if(result < 1)
                {
                    return NotFound();
                }
                return StatusCode(200, new { status = 200, message = "Destino deletado com sucesso" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }

        }

        [HttpPut]
        public IActionResult UpdateById([FromBody] DestinationModel destination)
        {
            try
            {
                var result = _repository.UpdateById(destination);
                if (result < 1)
                {
                    return NotFound();
                }
                return StatusCode(201, new { status = 201, message = "Destino atualizado com sucesso" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }
        [HttpPost]
        public IActionResult Insert([FromBody] DestinationModel destination)
        {
            try
            {
                var result = _repository.Insert(destination);
                if (result < 1)
                {
                    return BadRequest();
                }
                return StatusCode(201, destination);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }

        }
    }
}
