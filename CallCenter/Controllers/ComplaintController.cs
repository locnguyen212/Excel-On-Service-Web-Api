using CallCenter.Models;
using CallCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [Route("api/complaint")]
    [Authorize(Roles = "super admin, admin 1, admin 2")]
    public class ComplaintController : Controller
    {
        private IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpGet("find-all")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(await _complaintService.FindAll());
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
                return Ok(await _complaintService.FindById(id));
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
                return Ok(await _complaintService.FindByStaffId(id));
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
                return Ok(await _complaintService.FindByOrderId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] Complaint complaint)
        {
            try
            {
                //orderClient.StaffId = int.Parse(Request.Headers["id"]);
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _complaintService.Create(complaint)
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
                    Result = await _complaintService.Delete(id)
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
        public async Task<IActionResult> Update([FromBody] Complaint complaint)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new
                    {
                        Result = await _complaintService.Update(complaint)
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
