using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
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

    public class ProductUzbController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductUzbController(IProductService productService, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProductByIdView>> CreatProductUzb(ProductForCreate model,
            CancellationToken cancellation)
        {
            try
            {
                return Ok(await _productService.CreatAsync(3, model, cancellation));
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
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProductUzb(ProductForUpdate model,
            CancellationToken cancellation)
        {
            try
            {
                return Ok(await _productService.UpdateAsync(3, model, cancellation));
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
        public async Task<ActionResult<ProductByIdView>> GetProductUzb(int id)
        {
            try
            {
                var result = await _productService.GetAsync(3, null, null, p => p.id == id);

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
        public async Task<ActionResult<List<ProductForMainView>>> GetAllProductUzb(int pageSize, int pageIndex)
        {
            var products = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            try
            {
                var result = await _productService.GetAllAsync(3, products);

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
        //public async Task<ActionResult<List<ProductForMainView>>> GetAllProductByBrandNameUzb(int pageSize,
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
        //        return Ok(await _productService.GetBySortBrandName(3, products, brandName));
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

        //[Authorize]
        //[HttpDelete]
        //public async Task<ActionResult<bool>> DeleteProductAll(int id,
        //    CancellationToken cancellation)
        //{
        //    try
        //    {
        //        return Ok(await _productService.DeleteAsync(id, cancellation));
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

