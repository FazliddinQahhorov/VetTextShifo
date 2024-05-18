using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Customer.ForRequest;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Interfaces;

namespace VetTextShifo.API.Controllers.Auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
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
            CancellationToken cancellationToken)
        {
            try
            {
            return Ok(await _service.CreatAsync(request, cancellationToken));

            }
            catch (CustomException ex)
            {
                // Agar CustomException yuzaga kelsa
                return StatusCode(ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                // Agar metodda boshqa xatolik yuzaga kelsa
                return StatusCode(500, "Serverda xatolik yuzaga keldi: " + ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<AdminRespons>> GetById(int id)
        {
            try
            {
                return Ok(await _service.GetAsync(p => p.id == id));
            }
            catch (CustomException ex)
            {
                // Agar CustomException yuzaga kelsa
                return StatusCode(ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                // Agar metodda boshqa xatolik yuzaga kelsa
                return StatusCode(500, "Serverda xatolik yuzaga keldi: " + ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminRespons>>> GetAll(int pageSize, int pageIndex)
        {
            var @params = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            try
            {
                var admins = await _service.GetAllAsync(@params);
                return Ok(admins);
            }
            catch (CustomException ex)
            {
                // Agar CustomException yuzaga kelsa
                return StatusCode(ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                // Agar metodda boshqa xatolik yuzaga kelsa
                return StatusCode(500, "Serverda xatolik yuzaga keldi: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAdminData(AdminChangePassword request,
            CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _service.ChangePasswordAsync(request, cancellationToken));
            }
            catch (CustomException ex)
            {
                // Agar CustomException yuzaga kelsa
                return StatusCode(ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                // Agar metodda boshqa xatolik yuzaga kelsa
                return StatusCode(500, "Serverda xatolik yuzaga keldi: " + ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAdmin(int id, CancellationToken cancellation)
        {
            try
            {
                return Ok(await _service.DeleteAsync(id, cancellation));
            }
            catch (CustomException ex)
            {
                // Agar CustomException yuzaga kelsa
                return StatusCode(ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                // Agar metodda boshqa xatolik yuzaga kelsa
                return StatusCode(500, "Serverda xatolik yuzaga keldi: " + ex.Message);
            }
        }
    }
}
