using CallCenter.Models;
using CallCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [Authorize(Roles = "super admin, admin 2")]
    [Route("api/order-client-detail")]
    public class OrderClientDetailController : Controller
    {
        private IOrderClientDetailService _orderClientDetailService;

        public OrderClientDetailController(IOrderClientDetailService orderClientDetailService)
        {
            _orderClientDetailService = orderClientDetailService;
        }

        [HttpGet("find-all")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await _orderClientDetailService.FindAll());
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
                return Ok(await _orderClientDetailService.FindById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-by-order-client/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindByOrderClient(int id)
        {
            try
            {
                return Ok(await _orderClientDetailService.FindByOrderClientId(id));
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
                return Ok(await _orderClientDetailService.FindByCustomerId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-by-product/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindByProduct(int id)
        {
            try
            {
                return Ok(await _orderClientDetailService.FindByProductId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] OrderClientDetail orderClientDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _orderClientDetailService.Create(orderClientDetail)
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
                    Result = await _orderClientDetailService.Delete(id)
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
        public async Task<IActionResult> Update([FromBody] OrderClientDetail orderClientDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _orderClientDetailService.Update(orderClientDetail)
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
