using CallCenter.Models;
using CallCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [Route("api/order-client")]
    [Authorize(Roles = "super admin, admin 2")]
    public class OrderClientController : Controller
    {
        private IOrderClientService _orderClientService;

        public OrderClientController(IOrderClientService orderClientService)
        {
            _orderClientService = orderClientService;
        }

        [HttpGet("find-all")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await _orderClientService.FindAll());
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
                return Ok(await _orderClientService.FindById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-by-staff/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindByStaff(int id)
        {
            try
            {
                return Ok(await _orderClientService.FindByStaffId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-by-order/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindByOrder(int id)
        {
            try
            {
                return Ok(await _orderClientService.FindByOrderId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "super admin, admin 2, customer")]
        [HttpGet("find-by-customer/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindByCustomer(int id)
        {
            try
            {
                return Ok(await _orderClientService.FindByCustomerId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] OrderClient orderClient)
        {
            try
            {
                //orderClient.StaffId = int.Parse(Request.Headers["id"]);
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _orderClientService.Create(orderClient),
                        Id = orderClient.Id
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
        [Authorize(Roles = "super admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    Result = await _orderClientService.Delete(id)
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
        public async Task<IActionResult> Update([FromBody] OrderClient orderClient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _orderClientService.Update(orderClient)
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
