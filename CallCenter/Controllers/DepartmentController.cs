using CallCenter.Models;
using CallCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [Authorize(Roles = "super admin")]
    [Route("api/department")]
    public class DepartmentController : Controller
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("find-all")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await _departmentService.FindAll());
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
                return Ok(await _departmentService.FindById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _departmentService.Create(department)
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
                    Result = await _departmentService.Delete(id)
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
        public async Task<IActionResult> Update([FromBody] Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _departmentService.Update(department)
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
