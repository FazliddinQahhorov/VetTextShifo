using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Products.ForRequest;
using VetTextShifo.Application.DTOs.Products.ForView;
using VetTextShifo.Application.DTOs.Users.News.ForRequests;
using VetTextShifo.Application.DTOs.Users.News.ForResponse;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Application.Services;
using VetTextShifo.Domain.Entities.ProductDetails;

namespace VetTextShifo.API.Controllers.News
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class NewsEngController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public NewsEngController(INewsService newsService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _newsService = newsService;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<NewsForResponce>> CreatNewEng(NewsForRequest model,
            CancellationToken cancellation)
        {
            try
            {
                var result = await _newsService.CreatAsync(1, model, cancellation);
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


        [Authorize]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateNewEng(NewsForRequest model,
            CancellationToken cancellation)
        {
            try
            {
                return Ok(await _newsService.UpdateAsync(1, model, cancellation));
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
        public async Task<ActionResult<NewsForResponce>> GetNewEng(int id)
        {
            try
            {
                var result = await _newsService.GetAsync(1, p => p.id == id);

                // Bazaviy URL ni olish
                var request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";

                var relativePath = result.Attachments.FilePath.Replace(_webHostEnvironment.WebRootPath, "").Replace("\\", "/");
                result.Attachments.FilePath = $"{baseUrl}{relativePath}";
            
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
        public async Task<ActionResult<List<NewsForResponce>>> GetAllNewsEng(int pageSize, int pageIndex)
        {
            var products = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            try
            {
                var result = await _newsService.GetAllAsync(1, products);

                var request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";

                foreach (var item in result)
                {
                    var relativePath = item.Attachments.FilePath.Replace(_webHostEnvironment.WebRootPath, "").Replace("\\", "/");
                    item.Attachments.FilePath = $"{baseUrl}{relativePath}";
                }

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

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteNewAll(int id,
            CancellationToken cancellation)
        {
            try
            {
                return Ok(await _newsService.DeleteAsync(id, cancellation));
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
