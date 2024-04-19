using Microsoft.AspNetCore.Mvc;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Products.ForRequest;
using VetTextShifo.Application.DTOs.Products.ForView;
using VetTextShifo.Application.Interfaces;

namespace VetTextShifo.API.Controllers.Product
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductUzbController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductUzbController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductByIdView>> CreatProductUzb(ProductForCreate model,
            CancellationToken cancellation) =>
            Ok(await _productService.CreatAsync(3, model, cancellation));
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProductUzb(ProductForUpdate model,
            CancellationToken cancellation) =>
            Ok(await _productService.UpdateAsync(3, model, cancellation));
        [HttpGet]
        public async Task<ActionResult<ProductByIdView>> GetProductUzb(int id) =>
            Ok(await _productService.GetAsync(3, p => p.id == id));
        [HttpGet]
        public async Task<ActionResult<List<ProductForMainView>>> GetAllProductUzb(int pageSize, int pageIndex)
        {
            var products = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            return Ok(await _productService.GetAllAsync(3, products));
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductForMainView>>> GetAllProductByBrandNameUzb(int pageSize,
            int pageIndex,
            string brandName)
        {
            var products = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            return Ok(await _productService.GetBySortBrandName(3, products, brandName));
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProductAll(int id,
            CancellationToken cancellation) =>
            Ok(await _productService.DeleteAsync(id, cancellation));




    }

}

