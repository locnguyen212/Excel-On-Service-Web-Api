using CallCenter.Models;
using CallCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [Authorize(Roles = "super admin")]
    [Route("api/service")]
    public class ServiceController : Controller
    {
        private IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("find-all")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await _serviceService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                return Ok(await _serviceService.FindById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] Service service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _serviceService.Create(service)
                    });
                }
                return BadRequest(ModelState);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    Result = await _serviceService.Delete(id)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Update([FromBody] Service service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _serviceService.Update(service)
                    });
                }
                return BadRequest(ModelState);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
