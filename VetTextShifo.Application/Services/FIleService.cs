using VetTextShifo.Application.DTOs.Details.Attachments;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Entities.Attachments;
using VetTextShifo.Domain.Entities.ProductDetails.Products;

namespace VetTextShifo.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IGenericRepository<AttachmentModel> _repository;
        private readonly IGenericRepository<ProductEng> _repositoryEng;
        private readonly IGenericRepository<ProductRus> _repositoryRus;
        private readonly IGenericRepository<ProductUzb> _repositoryUzb;

        public FileService(IGenericRepository<AttachmentModel> repository,
            IGenericRepository<ProductEng> repositoryEng,
            IGenericRepository<ProductRus> repositoryRus,
            IGenericRepository<ProductUzb> repositoryUzb)
        {
            _repositoryEng = repositoryEng;
            _repositoryRus = repositoryRus;
            _repositoryUzb = repositoryUzb;
            _repository = repository;
        }

        public async Task<List<AttachmentForResponse>> CreateAttachment(AttachmentForRequest attachmentDtos, CancellationToken cancellationToken)
        {
            var response = new List<AttachmentForResponse>();
            foreach (var attachmentDto in attachmentDtos.attachments)
            {
                if (attachmentDto == null || attachmentDto.Length == 0)
                {
                    throw new Exception("Error: No file uploaded");
                }

                var folderName = "Resources";
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }

                var fileName = Path.GetFileName(attachmentDto.FileName);
                var fullPath = Path.Combine(pathToSave, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    attachmentDto.CopyTo(stream);
                }

                var attachmentModel = new AttachmentModel();

                // Fetching last items with deterministic sort order
                var lastEngData = _repositoryEng.GetAll().OrderByDescending(item => item.id).FirstOrDefault();
                if (lastEngData != null)
                {
                    attachmentModel.ProductEngId = lastEngData.id;
                }

                var lastRusData = _repositoryRus.GetAll().OrderByDescending(item => item.id).FirstOrDefault();
                if (lastRusData != null)
                {
                    attachmentModel.ProductRusId = lastRusData.id;
                }

                var lastUzbData = _repositoryUzb.GetAll().OrderByDescending(item => item.id).FirstOrDefault();
                if (lastUzbData != null)
                {
                    attachmentModel.ProductUzbId = lastUzbData.id; // Corrected property name
                }

                attachmentModel.Name = fileName;
                attachmentModel.Path = Path.Combine("Resources", fileName);

                await _repository.CreateAsync(attachmentModel);
                await _repository.SaveChangesAsync(cancellationToken);
                response.Add(new AttachmentForResponse
                {
                    FileName = fileName,
                    FilePath = Path.Combine("Resources", fileName)
                });
            }

            return response;
        }


        public async Task<AttachmentForResponse> GetForMainPageImage(int id, int languageId)
        {

            switch (languageId)
            {
                case 1:
                    var responseEng = _repository.GetAll().Where(p => p.ProductEngId == id).FirstOrDefault();
                    return new AttachmentForResponse
                    {
                        FileName = responseEng.Name,
                        FilePath = Path.Combine("Resources", responseEng.Name)
                    };
                    break;
                case 2:
                    var responseRus = _repository.GetAll().Where(p => p.ProductRusId == id).FirstOrDefault();
                    return new AttachmentForResponse
                    {
                        FileName = responseRus.Name,
                        FilePath = Path.Combine("Resources", responseRus.Name)
                    };
                    break;
                case 3:
                    var responseUzb = _repository.GetAll().Where(p => p.ProductUzbId == id).FirstOrDefault();
                    return new AttachmentForResponse
                    {
                        FileName = responseUzb.Name,
                        FilePath = Path.Combine("Resources", responseUzb.Name)
                    };
                    break;
                default:
                    throw new CustomException(404, "File not found");
                    break;
            }
        }

        public async Task<List<AttachmentForResponse>> GetForByIdImage(int id, int languageId)
        {

            switch (languageId)
            {
                case 1:
                    var DataEng = _repository.GetAll().Where(p => p.ProductEngId == id);
                    var responseEng = new List<AttachmentForResponse>();
                    foreach (var item in DataEng)
                    {
                        responseEng.Add(new AttachmentForResponse
                        {
                            FileName = item.Name,
                            FilePath = Path.Combine("Resources", item.Name)
                        });
                    }
                    return responseEng;
                    break;
                case 2:
                    var DataRus = _repository.GetAll().Where(p => p.ProductEngId == id);
                    var responseRus = new List<AttachmentForResponse>();
                    foreach (var item in DataRus)
                    {
                        responseRus.Add(new AttachmentForResponse
                        {
                            FileName = item.Name,
                            FilePath = Path.Combine("Resources", item.Name)
                        });
                    }
                    return responseRus;
                    break;
                case 3:
                    var DataUzb = _repository.GetAll().Where(p => p.ProductUzbId == id);
                    var responseUzb = new List<AttachmentForResponse>();
                    foreach (var item in DataUzb)
                    {
                        responseUzb.Add(new AttachmentForResponse
                        {
                            FileName = item.Name,
                            FilePath = Path.Combine("Resources", item.Name)
                        });
                    }
                    return responseUzb;
                    break;
                default:
                    throw new CustomException(404, "File not found");
                    break;
            }
        }
    }
}
