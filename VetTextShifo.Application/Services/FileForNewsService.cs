﻿using Microsoft.AspNetCore.Http;
using VetTextShifo.Application.DTOs.Details.Attachments;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Entities.Attachments;
using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.ProductDetails.NewsModel;
using VetTextShifo.Domain.Entities.ProductDetails.Products;

namespace VetTextShifo.Application.Services;

public class FileForNewsService : IFileForNewsService
{
    private readonly IGenericRepository<AttachmentForNew> _repository;
    private readonly IGenericRepository<NewsModelEng> _repositoryEng;
    private readonly IGenericRepository<NewsModelRus> _repositoryRus;
    private readonly IGenericRepository<NewsModelUzb> _repositoryUzb;

    public FileForNewsService(IGenericRepository<NewsModelUzb> repositoryUzb,
        IGenericRepository<NewsModelRus> repositoryRus,
        IGenericRepository<NewsModelEng> repositoryEng,
        IGenericRepository<AttachmentForNew> repository)
    {
        _repositoryUzb = repositoryUzb;
        _repositoryRus = repositoryRus;
        _repositoryEng = repositoryEng;
        _repository = repository;
    }

    public async Task<AttachmentForResponse> CreateAttachment(IFormFile attachmentDto,
        CancellationToken cancellationToken)
    {
        if (attachmentDto == null || attachmentDto.Length == 0)
        {
            throw new Exception("Error: No file uploaded");
        }

        var folderName = Path.GetFullPath("wwwroot\\Upload\\News");
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

        var attachmentModel = new AttachmentForNew();

        // Fetching last items with deterministic sort order
        var lastEngData = _repositoryEng.GetAll().OrderByDescending(item => item.id).FirstOrDefault();
        if (lastEngData != null)
        {
            attachmentModel.NewsModelEngId = lastEngData.id;
        }

        var lastRusData = _repositoryRus.GetAll().OrderByDescending(item => item.id).FirstOrDefault();
        if (lastRusData != null)
        {
            attachmentModel.NewsModelRusId = lastRusData.id;
        }

        var lastUzbData = _repositoryUzb.GetAll().OrderByDescending(item => item.id).FirstOrDefault();
        if (lastUzbData != null)
        {
            attachmentModel.NewsModelUzbId = lastUzbData.id; // Corrected property name
        }

        attachmentModel.Name = fileName;
        attachmentModel.Path = Path.Combine("wwwroot\\Upload\\News", fileName);

        await _repository.CreateAsync(attachmentModel);
        await _repository.SaveChangesAsync(cancellationToken);

        return new AttachmentForResponse
        {
            FileName = fileName,
            FilePath = Path.Combine("wwwroot\\Upload\\News", fileName)
        };
    }

    public async Task<AttachmentForResponse> GetForByIdImage(int id, int languageId)
    {
        switch (languageId)
        {
            case 1:
                var responseEng = await _repository.GetAsync(p => p.NewsModelEngId == id);
                return new AttachmentForResponse
                {
                    FileName = responseEng.Name,
                    FilePath = Path.Combine("\\Upload\\News", responseEng.Name)
                };
                break;
            case 2:
                var responseRus = await _repository.GetAsync(p => p.NewsModelRusId == id);
                return new AttachmentForResponse
                {
                    FileName = responseRus.Name,
                    FilePath = Path.Combine("\\Upload\\News", responseRus.Name)
                };
                break;
            case 3:
                var responseUzb = await _repository.GetAsync(p => p.NewsModelUzbId == id);
                return new AttachmentForResponse
                {
                    FileName = responseUzb.Name,
                    FilePath = Path.Combine("\\Upload\\News", responseUzb.Name)
                };
                break;
            default:
                throw new CustomException(404, "File not found");
                break;
        }
    }
}
