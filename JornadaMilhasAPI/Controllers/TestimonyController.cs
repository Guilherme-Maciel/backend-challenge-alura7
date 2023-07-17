using JornadaMilhasAPI.Repositories.Testimony;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhasAPI.Controllers
{
    [Route("api/depoimentos")]
    [ApiController]
    public class TestimonyController : Controller
    {
        private readonly ITestimonyRepository _testimony;
        public TestimonyController(ITestimonyRepository testimony)
        {
            _testimony = testimony;
        }

        [HttpGet]
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

        [HttpGet]
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
        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                
                if (!_testimony.delete())
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }
        [HttpPut]
        public IActionResult Update()
        {
            try
            {
                if (!_testimony.update())
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }
        [HttpPost]
        public IActionResult Insert()
        {
            throw new NotImplementedException();
        }
    }
}
