using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using VetTextShifo.API.Extensions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Products.ForRequest;
using VetTextShifo.Application.DTOs.Products.ForView;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Interfaces;

namespace VetTextShifo.API.Controllers.Product
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableRateLimiting("fixed")]

    public class ProductEngController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlHelper _urlHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IProductService _productService;

        public ProductEngController(IProductService productService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IUrlHelper urlHelper, IOptions<AppSettings> appSettings)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _urlHelper = urlHelper;
            _appSettings = appSettings;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProductByIdView>> CreatProductEng(ProductForCreate model,
            CancellationToken cancellation)
        {
            try
            {
                return Ok(await _productService.CreatAsync(1,model,cancellation));
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
        public async Task<ActionResult<bool>> UpdateProductEng(ProductForUpdate model,
            CancellationToken cancellation)
        {
            try
            {
                return Ok(await _productService.UpdateAsync(1,model,cancellation));
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
        public async Task<ActionResult<ProductByIdView>> GetProductEng(int id)
        {
            try
            {
                var result = await _productService.GetAsync(1, p => p.id == id);

                // Bazaviy URL ni olish
                var request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";

                foreach (var item in result.Files)
                {
                    var relativePath = item.FilePath.Replace(_webHostEnvironment.WebRootPath, "").Replace("\\", "/");
                    item.FilePath = $"{baseUrl}{relativePath}";
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



        [HttpGet]
        public async Task<ActionResult<List<ProductForMainView>>> GetAllProductEng(int pageSize, int pageIndex)
        {
            var products = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            try
            {
                var result = await _productService.GetAllAsync(1, products);

                var request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";

                foreach (var item in result)
                {
                    var relativePath = item.FilePath.Replace(_webHostEnvironment.WebRootPath, "").Replace("\\", "/");
                    item.FilePath = $"{baseUrl}{relativePath}";
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
        //[HttpGet]
        //public async Task<ActionResult<List<ProductForMainView>>> GetAllProductByBrandNameEng(int pageSize,
        //    int pageIndex,
        //    string brandName)
        //{
        //    var products = new PaginationParams
        //    {
        //        PageSize = pageSize,
        //        PageIndex = pageIndex
        //    };

        //    try
        //    {
        //        return Ok(await _productService.GetBySortBrandName(1, products, brandName));
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

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProductAll(int id,
            CancellationToken cancellation)
        {
            try
            {
                return Ok(await _productService.DeleteAsync(id,cancellation));
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
