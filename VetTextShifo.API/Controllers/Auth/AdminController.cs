using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Customer;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Application.Interfaces;

namespace VetTextShifo.API.Controllers.Auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<AdminRespons>> CreateAdmin([FromForm] AdminRequest request,
            CancellationToken cancellationToken) =>
            Ok(await _service.CreatAsync(request, cancellationToken));


        [HttpGet]
        public async Task<ActionResult<AdminRespons>> GetById(int id) =>
            Ok(await _service.GetAsync(p => p.id == id));


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminRespons>>> GetAll(int pageSize, int pageIndex)
        {
            var @params = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            var admins = await _service.GetAllAsync(@params);
            return Ok(admins);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAdminData(AdminChangePassword request,
            CancellationToken cancellationToken) =>
            Ok(await _service.ChangePasswordAsync(request, cancellationToken));
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAdmin(int id, CancellationToken cancellation) =>
            Ok(await _service.DeleteAsync(id, cancellation));
    }
}
