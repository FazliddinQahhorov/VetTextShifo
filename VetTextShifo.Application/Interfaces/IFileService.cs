using Microsoft.AspNetCore.Http;
using VetTextShifo.Application.DTOs.Details.Attachments;
namespace VetTextShifo.Application.Interfaces
{
    public interface IFileService
    {
        public Task<List<AttachmentForResponse>> CreateAttachment(AttachmentForRequest attachmentDto, CancellationToken cancellationToken);
        public Task<AttachmentForResponse> GetForMainPageImage(int id, int languageId);
        public Task<List<AttachmentForResponse>> GetForByIdImage(int id, int languageId);
    }
}
