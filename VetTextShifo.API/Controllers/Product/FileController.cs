using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using VetTextShifo.Application.DTOs.Details.Attachments;
using VetTextShifo.Application.Interfaces;

namespace VetTextShifo.API.Controllers.Product
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    [EnableRateLimiting("fixed")]

    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IFileForNewsService _fileForNewsService;

        public FileController(IFileService fileService, IFileForNewsService fileForNewsService)
        {
            _fileService = fileService;
            _fileForNewsService = fileForNewsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAttachmentsForProducts(AttachmentForRequest request, CancellationToken cancellation) =>
            Ok(await _fileService.CreateAttachment(request, cancellation));

        [HttpPost]
        public async Task<IActionResult> AddAttachmentForNews(IFormFile? request, CancellationToken cancellation) =>
           Ok(await _fileForNewsService.CreateAttachment(request, cancellation));
    }
}
