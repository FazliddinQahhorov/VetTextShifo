using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Domain.Entities;
using Interviewer.Application.Extensions;
using VetTextShifo.Data.Interfaces;
using Microsoft.AspNetCore.RateLimiting;


namespace VetTextShifo.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]

    public class LoginController(IAuthService service, IGenericRepository<Admin> userService, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> login(Admin signIn)
        {
            try
            {
                var user = await userService.GetAsync(u => u.email == signIn.email);
                if (user == null || user.password != signIn.password.Encrypt())
                {
                    throw new CustomException(404, "E-mail or Password is not correct");

                }
                var token = await service.GenerateToken(signIn);
                return Ok(token);
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
