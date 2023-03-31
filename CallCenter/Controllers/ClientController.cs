using CallCenter.Models;
using CallCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [Route("api/client")]
    [Authorize(Roles = "super admin, customer")]
    public class ClientController : Controller
    {
        private IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("find-all")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await _clientService.FindAll());
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
                return Ok(await _clientService.FindById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-by-customer/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindByCustomer(int id)
        {
            try
            {
                return Ok(await _clientService.FindByCustomerId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            try
            {
                //client.CustomerId = int.Parse(Request.Headers["id"]);
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _clientService.Create(client)
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
                    Result = await _clientService.Delete(id)
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
        public async Task<IActionResult> Update([FromBody] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _clientService.Update(client)
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
