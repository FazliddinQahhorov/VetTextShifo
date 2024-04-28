using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Products.Comments;
using VetTextShifo.Application.DTOs.Products.ForRequest;
using VetTextShifo.Application.DTOs.Products.ForView;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Application.Services;
using VetTextShifo.Domain.Entities.ProductDetails;

namespace VetTextShifo.API.Controllers.Product
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commmentService;
        public CommentController(ICommentService commmentService)
        {
            _commmentService = commmentService;
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> CreatComment(CommentForCreate model,
           CancellationToken cancellation) =>
           Ok(await _commmentService.CreatAsync(model, cancellation));
        [HttpGet]
        public async Task<ActionResult<ProductByIdView>> GetComment(int id) =>
            Ok(await _commmentService.GetAsync(p => p.id == id));
        [HttpGet]
        public async Task<ActionResult<List<ProductForMainView>>> GetAllComments(int pageSize, int pageIndex)
        {
            var products = new PaginationParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            return Ok(await _commmentService.GetAllAsync( products));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteComment(int id,
            CancellationToken cancellation) =>
            Ok(await _commmentService.DeleteAsync(id, cancellation));

    }
}
