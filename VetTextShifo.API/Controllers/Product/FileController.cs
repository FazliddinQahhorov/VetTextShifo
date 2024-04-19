using Microsoft.AspNetCore.Mvc;
using VetTextShifo.Application.DTOs.Details.Attachments;
using VetTextShifo.Application.Interfaces;

namespace VetTextShifo.API.Controllers.Product
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAttachments(AttachmentForRequest request, CancellationToken cancellation) =>
            Ok(await _fileService.CreateAttachment(request, cancellation));
    }
}
