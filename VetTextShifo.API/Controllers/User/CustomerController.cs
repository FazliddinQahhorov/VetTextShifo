using Microsoft.AspNetCore.Mvc;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Customer.ForRequest;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Application.Interfaces;

namespace VetTextShifo.API.Controllers.User
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerController(ICustomerService customerService, IHttpContextAccessor httpContextAccessor)
        {
            _customerService = customerService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerForView>> Create([FromForm] CustomerForCreateRequest request,
                   CancellationToken cancellationToken)
        {
            request.CustomerIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            return Ok(await _customerService.CreateAsync(request, cancellationToken));
        }


        [HttpGet]
        public async Task<ActionResult<CustomerForView>> GetById(int id) =>
            Ok(await _customerService.GetAsync(p => p.id == id));


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerForView>>> GetAll(int pageSize, int pageIndex)
        {
            var @params = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            var admins = await _customerService.GetAllAsync(@params);
            return Ok(admins);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update(int id, CustomerForUpdateRequest request,
            CancellationToken cancellationToken) =>
            Ok(await _customerService.UpdateAsync(id, request, cancellationToken));

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int id, CancellationToken cancellation) =>
            Ok(await _customerService.DeleteAsync(id, cancellation));
    }
}
