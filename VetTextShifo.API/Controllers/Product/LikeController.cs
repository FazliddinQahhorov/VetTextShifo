using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Domain.Entities.ProductDetails;

namespace VetTextShifo.API.Controllers.Product
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LikeController(IHttpContextAccessor httpContextAccessor, ILikeService likeService)
        {
            _likeService = likeService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> LikedOrDisLiked(string ModelName, CancellationToken cancellationToken)
        {
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrEmpty(ipAddress))
            {
                return BadRequest("IP address could not be retrieved.");
            }

            Likes like = new Likes()
            {
                ProductModelName = ModelName,
                CustomerIP = ipAddress
            };

            var response = _likeService.AddLikeProduct(like, cancellationToken);

            return Ok(response);
        }
    }
}
