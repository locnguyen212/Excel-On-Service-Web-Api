using CallCenter.Models;
using CallCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [Authorize(Roles = "super admin")]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("find-all")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await _productService.FindAll());
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
                return Ok(await _productService.FindById(id));
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
                return Ok(await _productService.FindByCustomerId(id));
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
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            try
            {
                //product.CustomerId = int.Parse(Request.Headers["id"]);
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _productService.Create(product)
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
                    Result = await _productService.Delete(id)
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
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _productService.Update(product)
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
