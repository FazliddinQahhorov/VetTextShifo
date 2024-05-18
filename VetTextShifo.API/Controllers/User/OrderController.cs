using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Customer.ForRequest;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Application.DTOs.Users.Orders.ForRequest;
using VetTextShifo.Application.DTOs.Users.Orders.ForView;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Domain.Entities.Users;

namespace VetTextShifo.API.Controllers.User
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableRateLimiting("fixed")]

    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrderController(IOrderService orderService, IHttpContextAccessor httpContextAccessor)
        {
            _orderService = orderService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder( OrderForRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var ip = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                var result = await _orderService.CreateOrder(request, cancellationToken);
                return Ok(result);
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
        public async Task<ActionResult<Order>> GetById(int id)
        {
            try
            {
                return Ok(await _orderService.GetOrder(p => p.id == id));
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
        public async Task<ActionResult<IEnumerable<Order>>> GetAll(int pageSize, int pageIndex)
        {
            var @params = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            try
            {
                var admins = await _orderService.GetAllOrders(@params);
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

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAdminData(OrderForView request,
            CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _orderService.UpdateOrder(request, cancellationToken));
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

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAdmin(int id, CancellationToken cancellation)
        {
            try
            {
                return Ok(await _orderService.DeleteOrder(id, cancellation));
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

