using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Products.ForRequest;
using VetTextShifo.Application.DTOs.Products.ForView;
using VetTextShifo.Application.Interfaces;

namespace VetTextShifo.API.Controllers.Product
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductRusController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductRusController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductByIdView>> CreatProductRus(ProductForCreate model,
            CancellationToken cancellation) =>
            Ok(await _productService.CreatAsync(2, model, cancellation));
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProductRus(ProductForUpdate model,
            CancellationToken cancellation) =>
            Ok(await _productService.UpdateAsync(2, model, cancellation));
        [HttpGet]
        public async Task<ActionResult<ProductByIdView>> GetProductRus(int id) =>
            Ok(await _productService.GetAsync(2, p => p.id == id));
        [HttpGet]
        public async Task<ActionResult<List<ProductForMainView>>> GetAllProductRus(int pageSize, int pageIndex)
        {
            var products = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            return Ok(await _productService.GetAllAsync(2, products));
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductForMainView>>> GetAllProductByBrandNameRus(int pageSize,
            int pageIndex,
            string brandName)
        {
            var products = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            return Ok(await _productService.GetBySortBrandName(2, products, brandName));
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProductAll(int id,
            CancellationToken cancellation) =>
            Ok(await _productService.DeleteAsync(id, cancellation));




    }
}

