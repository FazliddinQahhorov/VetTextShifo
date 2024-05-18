using Microsoft.AspNetCore.Http;
using VetTextShifo.Application.DTOs.Details.Attachments;

namespace VetTextShifo.Application.Interfaces;
public interface IFileForNewsService
{
    public Task<AttachmentForResponse> CreateAttachment(IFormFile? attachmentDto,
        CancellationToken cancellationToken);
    public Task<AttachmentForResponse> GetForByIdImage(int id, int languageId);
}
