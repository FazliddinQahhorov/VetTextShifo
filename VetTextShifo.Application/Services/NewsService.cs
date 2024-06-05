using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.News.ForRequests;
using VetTextShifo.Application.DTOs.Users.News.ForResponse;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Extansions;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Entities.Attachments;
using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.ProductDetails.NewsModel;

namespace VetTextShifo.Application.Services;

public class NewsService : INewsService
{
    private readonly IGenericRepository<NewsModelEng> _repositoryEng;
    private readonly IGenericRepository<NewsModelRus> _repositoryRus;
    private readonly IGenericRepository<NewsModelUzb> _repositoryUzb;
    private readonly IGenericRepository<AttachmentForNew> _attachmentForNewRepository;
    private readonly IFileForNewsService _fileForNewsService;
    private readonly IMapper _mapper;

    public NewsService(IMapper mapper,
        IFileForNewsService fileForNewsService,
        IGenericRepository<NewsModelUzb> repositoryUzb,
        IGenericRepository<NewsModelRus> repositoryRus,
        IGenericRepository<NewsModelEng> repositoryEng)
    {
        _mapper = mapper;
        _fileForNewsService = fileForNewsService;
        _repositoryUzb = repositoryUzb;
        _repositoryRus = repositoryRus;
        _repositoryEng = repositoryEng;
    }

    public async Task<NewsForResponce> CreatAsync(int languageId, NewsForRequest userCreation,
        CancellationToken cancellationToken)
    {
        switch (languageId)
        {
            case 1:
                var modelEng = await _repositoryEng.GetAsync(p => p.Title == userCreation.Title);
                if (modelEng is not null)
                {
                    throw new CustomException(400, "This new already exsist!");
                }

                var mappedEng = await _repositoryEng.CreateAsync(_mapper.Map<NewsModelEng>(userCreation));
                await _repositoryEng.SaveChangesAsync(cancellationToken);
                return _mapper.Map<NewsForResponce>(mappedEng);
                break;
            case 2:
                var modelRus = await _repositoryRus.GetAsync(p => p.Title == userCreation.Title);
                if (modelRus is not null)
                {
                    throw new CustomException(400, "This new already exsist!");
                }

                var mappedRus = await _repositoryRus.CreateAsync(_mapper.Map<NewsModelRus>(userCreation));
                await _repositoryEng.SaveChangesAsync(cancellationToken);
                return _mapper.Map<NewsForResponce>(mappedRus);
                break;
            case 3:
                var modelUzb = await _repositoryUzb.GetAsync(p => p.Title == userCreation.Title);
                if (modelUzb is not null)
                {
                    throw new CustomException(400, "This new already exsist!");
                }

                var mappedUzb = await _repositoryUzb.CreateAsync(_mapper.Map<NewsModelUzb>(userCreation));
                await _repositoryEng.SaveChangesAsync(cancellationToken);
                return _mapper.Map<NewsForResponce>(mappedUzb);
                break;
            default:
                throw new CustomException(404, "Unknown index language");
                break;
        }
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var modelEng = await _repositoryEng.GetAsync(p => p.id == id);
        var modelRus = await _repositoryRus.GetAsync(p => p.id == id);
        var modelUzb = await _repositoryUzb.GetAsync(p => p.id == id);

        if (modelEng == null || modelRus == null || modelUzb == null)
        {
            throw new CustomException(400, "Product not found!");
        }

        var pathToSave = Path.GetFullPath("wwwroot\\Upload\\News");

        var file = await _fileForNewsService.GetForByIdImage(id, 1);

        await _repositoryEng.DeleteAsync(p => p.id == id);
        await _repositoryEng.SaveChangesAsync(cancellationToken);

        await _repositoryRus.DeleteAsync(p => p.id == id);
        await _repositoryRus.SaveChangesAsync(cancellationToken);

        await _repositoryUzb.DeleteAsync(p => p.id == id);
        await _repositoryUzb.SaveChangesAsync(cancellationToken);

      
            var filePath = Path.Combine(pathToSave, file.FileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        

        return true;

    }

    public async Task<IEnumerable<NewsForResponce>> GetAllAsync(int languageId, PaginationParams @params)
    {
        switch (languageId)
        {
            case 1:
                var NewsEng = _repositoryEng.GetAll().
                    ToPagedListNewsEng(@params).
                    ToList();
                var NewsEngMap = _mapper.Map<IEnumerable<NewsForResponce>>(NewsEng);
                foreach (var item in NewsEngMap)
                {
                    var image = await _fileForNewsService.GetForByIdImage(item.Id, languageId);
                    item.Attachments = image;
                }
               
                return NewsEngMap;
                break;
            case 2:
                var NewsRus = _repositoryRus.GetAll().
                    ToPagedListNewsRus(@params).
                    ToList();
                var NewsRusMap = _mapper.Map<IEnumerable<NewsForResponce>>(NewsRus);
                foreach (var item in NewsRusMap)
                {
                    var image = await _fileForNewsService.GetForByIdImage(item.Id, languageId);
                    item.Attachments = image;
                }
                return NewsRusMap;
                break;
            case 3:
                var NewsUzb = _repositoryUzb.GetAll().
                    ToPagedListNewsUzb(@params).
                    ToList();
                var NewsUzbMap = _mapper.Map<IEnumerable<NewsForResponce>>(NewsUzb);
                foreach (var item in NewsUzbMap)
                {
                    var image = await _fileForNewsService.GetForByIdImage(item.Id, languageId);
                    item.Attachments = image;
                }
                return NewsUzbMap;
                break;
            default:
                throw new CustomException(404, "Data not found!");
                break;
        }
    }

    public async Task<NewsForResponce> GetAsync(int languageId,
        Expression<Func<NewsModelEng, bool>>? expressionEng = null,
        Expression<Func<NewsModelRus, bool>>? expressionRus = null,
        Expression<Func<NewsModelUzb, bool>>? expressionUzb = null)
    {
        switch (languageId)
        {
            case 1:
                var mapEn = _mapper.Map<NewsForResponce>(await _repositoryEng.GetAsync(expressionEng));
                mapEn.Attachments = await _fileForNewsService.GetForByIdImage(mapEn.Id, languageId);
                return mapEn;
                break;
            case 2:
                var mapRu = _mapper.Map<NewsForResponce>(await _repositoryRus.GetAsync(expressionRus));
                mapRu.Attachments = await _fileForNewsService.GetForByIdImage(mapRu.Id, languageId);
                return mapRu;
                break;
            case 3:
                var mapUz = _mapper.Map<NewsForResponce>(await _repositoryUzb.GetAsync(expressionUzb));
                mapUz.Attachments = await _fileForNewsService.GetForByIdImage(mapUz.Id, languageId);
                return mapUz;
                break;
            default:
                throw new CustomException(404, "Data not exsist");
                break;
        }
    }

    public async Task<bool> UpdateAsync(int languageId, NewsForRequest newsModel, 
        CancellationToken cancellationToken)
    {
       

        switch (languageId)
        {
            case 1:
                var productEng = await _repositoryEng.GetAsync(p => p.id == newsModel.id);
                if (productEng is null)
                {
                    throw new CustomException(400, "News not found!");
                }
                productEng.Title = newsModel.Title;
                productEng.Description = newsModel.Description;
                var mappedEng = await _repositoryEng.UpdateAsync(productEng);
                await _repositoryEng.SaveChangesAsync(cancellationToken);
                return true;
                break;
            case 2:
                var productRus = await _repositoryRus.GetAsync(p => p.id == newsModel.id);
                if (productRus is null)
                {
                    throw new CustomException(400, "News not found!");
                }
                productRus.Title = newsModel.Title;
                productRus.Description = newsModel.Description;
                var mappedRus = await _repositoryRus.UpdateAsync(productRus);
                await _repositoryRus.SaveChangesAsync(cancellationToken);
                return true;
                break;
            case 3:
                var productUzb = await _repositoryUzb.GetAsync(p => p.id == newsModel.id);
                if (productUzb is null)
                {
                    throw new CustomException(400, "News not found!");
                }
                productUzb.Title = newsModel.Title;
                productUzb.Title = newsModel.Title;
                var mappedUzb = await _repositoryUzb.UpdateAsync(productUzb);
                await _repositoryUzb.SaveChangesAsync(cancellationToken);
                return true;
                break;
            default:
                throw new CustomException(404, "Unknown index language");
                break;
        }
    }
}
