using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Products.ForView;
using VetTextShifo.Application.DTOs.Users.News.ForRequests;
using VetTextShifo.Application.DTOs.Users.News.ForResponse;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Interfaces;

namespace VetTextShifo.API.Controllers.News
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class NewsRusController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NewsRusController(INewsService newsService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
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
                return Ok(await _newsService.CreatAsync(2, model, cancellation));
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
        public async Task<ActionResult<bool>> UpdateNewRus(NewsForRequest model,
            int id,
            CancellationToken cancellation)
        {
            try
            {
                return Ok(await _newsService.UpdateAsync(2, model, cancellation));
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
        public async Task<ActionResult<NewsForResponce>> GetNewRus(int id)
        {
            try
            {
                var result = await _newsService.GetAsync(2,null, p => p.id == id, null);

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
        public async Task<ActionResult<List<NewsForResponce>>> GetAllNewsRus(int pageSize, int pageIndex)
        {
            var products = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            try
            {
                var result = await _newsService.GetAllAsync(2, products);

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

        //[Authorize]
        //[HttpDelete]
        //public async Task<ActionResult<bool>> DeleteNewAll(int id,
        //    CancellationToken cancellation)
        //{
        //    try
        //    {
        //        return Ok(await _newsService.DeleteAsync(id, cancellation));
        //    }
        //    catch (CustomException ex)
        //    {
        //        // Agar CustomException yuzaga kelsa
        //        return StatusCode(ex.Code, ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Agar metodda boshqa xatolik yuzaga kelsa
        //        return StatusCode(500, "Serverda xatolik yuzaga keldi: " + ex.Message);
        //    }
        //}

    }
}
