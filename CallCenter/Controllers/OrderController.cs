using CallCenter.Models;
using CallCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [Authorize(Roles = "super admin")]
    [Route("api/order")]
    public class OrderController : Controller
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("find-all")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await _orderService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-staff-null")]
        [Produces("application/json")]
        public async Task<IActionResult> FindStaffNull()
        {
            try
            {
                //Console.WriteLine("ID: " + Request.Headers["id"]);
                return Ok(await _orderService.FindStaffNull());
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
                return Ok(await _orderService.FindById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-by-staff/{id}")]
        [Produces("application/json")]
        [Authorize(Roles = "super admin, admin 2")]
        public async Task<IActionResult> FindByStaff(int id)
        {
            try
            {
                return Ok(await _orderService.FindByStaff(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-by-customer/{id}")]
        [Produces("application/json")]
        [Authorize(Roles = "super admin, customer")]
        public async Task<IActionResult> FindByCustomer(int id)
        {
            try
            {
                return Ok(await _orderService.FindByCustomer(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-by-service/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindByService(int id)
        {
            try
            {
                return Ok(await _orderService.FindByService(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "super admin, customer")]
        public async Task<IActionResult> Create([FromBody] Order order)
        {           
            try
            {
                if (ModelState.IsValid)
                {
                    order.Status = true;
                    return Ok(new
                    {
                        Result = await _orderService.Create(order)
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
                    Result = await _orderService.Delete(id)
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
        [Authorize(Roles = "super admin")]
        public async Task<IActionResult> Update([FromBody] Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var baseOrder = await _orderService.FindOrderController(order.Id);
                    var implOrder = order;
                    if (baseOrder.StaffId == null && implOrder.StaffId != null)
                    {
                        implOrder.StartedAt = DateTime.Now;
                    }
                    return Ok(new
                    {
                        Result = await _orderService.Update(implOrder)
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
