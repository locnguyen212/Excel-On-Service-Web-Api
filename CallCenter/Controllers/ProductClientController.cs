using CallCenter.Models;
using CallCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [Route("api/product-client")]
    [Authorize(Roles = "super admin")]
    public class ProductClientController : Controller
    {
        private IProductClientService _productClientService;

        public ProductClientController(IProductClientService productClientService)
        {
            _productClientService = productClientService;
        }

        [HttpGet("find-all")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await _productClientService.FindAll());
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
                return Ok(await _productClientService.FindById(id));
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
                return Ok(await _productClientService.FindByProductId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-by-client/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindByClient(int id)
        {
            try
            {
                return Ok(await _productClientService.FindByClientId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("find-by-customer/{id}")]
        [Produces("application/json")]
        [Authorize(Roles = "super admin, admin 2, customer")]
        public async Task<IActionResult> FindByCustomer(int id)
        {
            try
            {
                return Ok(await _productClientService.FindByCustomerId(id));
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
        public async Task<IActionResult> Create([FromBody] ProductClient productClient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _productClientService.Create(productClient)
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
        [Authorize(Roles = "super admin, customer")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    Result = await _productClientService.Delete(id)
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
        [Authorize(Roles = "super admin, customer")]
        public async Task<IActionResult> Update([FromBody] ProductClient productClient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _productClientService.Update(productClient)
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
