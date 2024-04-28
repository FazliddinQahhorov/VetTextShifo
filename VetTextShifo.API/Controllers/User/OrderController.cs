using Microsoft.AspNetCore.Mvc;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Customer.ForRequest;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Application.DTOs.Users.Orders.ForRequest;
using VetTextShifo.Application.Interfaces;

namespace VetTextShifo.API.Controllers.User
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<AdminRespons>> CreateAdmin([FromForm] OrderForRequest request,
            CancellationToken cancellationToken) =>
            Ok(await _orderService.CreateOrder(request, cancellationToken));


        [HttpGet]
        public async Task<ActionResult<AdminRespons>> GetById(int id) =>
            Ok(await _orderService.GetOrder(p => p.id == id));


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminRespons>>> GetAll(int pageSize, int pageIndex)
        {
            var @params = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            var admins = await _orderService.GetAllOrders(@params);
            return Ok(admins);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAdminData(int id, OrderForRequest request,
            CancellationToken cancellationToken) =>
            Ok(await _orderService.UpdateOrder(id, request, cancellationToken));

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAdmin(int id, CancellationToken cancellation) =>
            Ok(await _orderService.DeleteOrder(id, cancellation));
    }
}

