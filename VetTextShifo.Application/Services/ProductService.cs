using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Products.ForRequest;
using VetTextShifo.Application.DTOs.Products.ForView;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Extansions;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Entities;
using VetTextShifo.Domain.Entities.Attachments;
using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.ProductDetails.Products;

namespace VetTextShifo.Application.Services;

public class ProductService : IProductService
{
    private readonly IGenericRepository<ProductEng> _repositoryEng;
    private readonly IGenericRepository<ProductRus> _repositoryRus;
    private readonly IGenericRepository<ProductUzb> _repositoryUzb;
    private readonly IGenericRepository<Comment> _commentRepository;
    private readonly IGenericRepository<AttachmentModel> _attachmentRepository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public ProductService(IGenericRepository<ProductEng> repositoryEng,
        IGenericRepository<ProductRus> repositoryRus,
        IGenericRepository<ProductUzb> repositoryUzb,
        IMapper mapper,
        IFileService fileService,
        IGenericRepository<Comment> commentRepository,
        IGenericRepository<AttachmentModel> attachmentRepository)
    {
        _repositoryEng = repositoryEng;
        _repositoryRus = repositoryRus;
        _repositoryUzb = repositoryUzb;
        _mapper = mapper;
        _fileService = fileService;
        _commentRepository = commentRepository;
        _attachmentRepository = attachmentRepository;
    }


    public async Task<ProductByIdView> CreatAsync(int languageId,
        ProductForCreate productCreation,
        CancellationToken cancellationToken)
    {
        switch (languageId)
        {
            case 1:
                var productEng = await _repositoryEng.GetAsync(p => p.ModelName == productCreation.ModelName);
                if (productEng is not null)
                {
                    throw new CustomException(400, "Product already exsist!");
                }

                var mappedEng = await _repositoryEng.CreateAsync(_mapper.Map<ProductEng>(productCreation));
                await _repositoryEng.SaveChangesAsync(cancellationToken);
                return _mapper.Map<ProductByIdView>(mappedEng);
                break;
            case 2:
                var productRus = await _repositoryRus.GetAsync(p => p.ModelName == productCreation.ModelName);
                if (productRus is not null)
                {
                    throw new CustomException(400, "Product already exsist!");
                }

                var mappedRus = await _repositoryRus.CreateAsync(_mapper.Map<ProductRus>(productCreation));
                await _repositoryEng.SaveChangesAsync(cancellationToken);
                return _mapper.Map<ProductByIdView>(mappedRus);
                break;
            case 3:
                var productUzb = await _repositoryUzb.GetAsync(p => p.ModelName == productCreation.ModelName);
                if (productUzb is not null)
                {
                    throw new CustomException(400, "Product already exsist!");
                }

                var mappedUzb = await _repositoryUzb.CreateAsync(_mapper.Map<ProductUzb>(productCreation));
                await _repositoryEng.SaveChangesAsync(cancellationToken);
                return _mapper.Map<ProductByIdView>(mappedUzb);
                break;
            default:
                throw new CustomException(404, "Unknown index language");
                break;
        }


    }

    public async Task<bool> DeleteAsync(int id,
        CancellationToken cancellationToken)
    {
        var productEng = await _repositoryEng.GetAsync(p => p.id == id);
        var productRus = await _repositoryRus.GetAsync(p => p.id == id);
        var productUzb = await _repositoryUzb.GetAsync(p => p.id == id);
        var pathToSave = Path.GetFullPath("wwwroot\\Upload\\Products");
        var files = await _attachmentRepository.GetAll().
            Where(p => p.ProductEngId == productEng.id).
            ToListAsync();
        if (productEng is null || productRus is null || productUzb is null)
        {
            throw new CustomException(400, "Product not found!");
        }

        await _repositoryEng.DeleteAsync(p => p.id == id);
        await _repositoryEng.SaveChangesAsync(cancellationToken);
        await _repositoryRus.DeleteAsync(p => p.id == id);
        await _repositoryRus.SaveChangesAsync(cancellationToken);
        await _repositoryUzb.DeleteAsync(p => p.id == id);
        await _repositoryUzb.SaveChangesAsync(cancellationToken);
        foreach(var item in files)
        {
            File.Delete(Path.Combine(pathToSave, item.Name));
        }

        return true;
    }



    public async Task<IEnumerable<ProductForMainView>> GetAllAsync(int languageId
        , PaginationParams @params)
    {
        switch (languageId)
        {
            case 1:
                var productsEng = _repositoryEng.GetAll().
                    ToPagedListProductEng(@params)
                    .ToList();
                var soretedListEng = new List<ProductForMainView>();
                foreach (var item in productsEng)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {   
                        id = item.id,
                        ModelName = item.ModelName,
                        BrandName = item.BrandName,
                        GuaranteePeriod = item.GuaranteePeriod,
                        Service = item.Service,
                        MadeIn = item.MadeIn,
                        Produced = item.Produced,
                        ExtraDevices = item.ExtraDevices,
                        Description = item.Description,
                        PaymentContract = item.PaymentContract,
                        PaymentType = item.PaymentType,
                        FileName = image.FileName,
                        FilePath = image.FilePath,
                    };

                    soretedListEng.Add(productEng);
                }
                return soretedListEng;
                break;
            case 2:
                var productsRus = _repositoryRus.GetAll().
                   ToPagedListProductRus(@params)
                   .ToList();
                var soretedListRus = new List<ProductForMainView>();

                foreach (var item in productsRus)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {
                        id = item.id,
                        ModelName = item.ModelName,
                        BrandName = item.BrandName,
                        GuaranteePeriod = item.GuaranteePeriod,
                        Service = item.Service,
                        MadeIn = item.MadeIn,
                        Produced = item.Produced,
                        ExtraDevices = item.ExtraDevices,
                        Description = item.Description,
                        PaymentContract = item.PaymentContract,
                        PaymentType = item.PaymentType,
                        FileName = image.FileName,
                        FilePath = image.FilePath
                    };

                    soretedListRus.Add(productEng);
                }
                return soretedListRus;
                break;
            case 3:
                var productsUzb = _repositoryUzb.GetAll().
                   ToPagedListProductUzb(@params)
                   .ToList();
                var soretedListUzb = new List<ProductForMainView>();

                foreach (var item in productsUzb)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {
                        id = item.id,
                        ModelName = item.ModelName,
                        BrandName = item.BrandName,
                        GuaranteePeriod = item.GuaranteePeriod,
                        Service = item.Service,
                        MadeIn = item.MadeIn,
                        Produced = item.Produced,
                        ExtraDevices = item.ExtraDevices,
                        Description = item.Description,
                        PaymentContract = item.PaymentContract,
                        PaymentType = item.PaymentType,
                        FileName = image.FileName,
                        FilePath = image.FilePath
                    };

                    soretedListUzb.Add(productEng);
                }
                return soretedListUzb;
                break;
            default:
                throw new CustomException(404, "Data not found!");
                break;
        }
    }

    public async Task<ProductByIdView> GetAsync(int languageId,
        Expression<Func<ProductEng, bool>>? expressionEng = null,
        Expression<Func<ProductRus, bool>>? expressionRus = null,
        Expression<Func<ProductUzb, bool>>? expressionUzb = null)
    {

        switch (languageId)
        {
            case 1:
                var mapEn = _mapper.Map<ProductByIdView>(await _repositoryEng.GetAsync(expressionEng));
                mapEn.comments = await _commentRepository.GetAll().Where(p => p.ProductModel == mapEn.ModelName).ToListAsync(); 
                mapEn.Files = await _fileService.GetForByIdImage(mapEn.id, languageId);
                mapEn.Rating = 4;
                return mapEn;
                break;
            case 2:
                var mapRu = _mapper.Map<ProductByIdView>(await _repositoryRus.GetAsync(expressionRus));
                mapRu.comments = await _commentRepository.GetAll().Where(p => p.ProductModel == mapRu.ModelName).ToListAsync();
                mapRu.Files = await _fileService.GetForByIdImage(mapRu.id, languageId);
                mapRu.Rating = 4;
                return mapRu;
                break;
            case 3:
                var mapUz = _mapper.Map<ProductByIdView>(await _repositoryUzb.GetAsync(expressionUzb));
                mapUz.comments = await _commentRepository.GetAll().Where(p => p.ProductModel == mapUz.ModelName).ToListAsync();
                mapUz.Files = await _fileService.GetForByIdImage(mapUz.id, languageId);
                mapUz.Rating = 4;
                return mapUz;
                break;
            default:
                throw new CustomException(404, "Product not exsist");
                break;
        }
    }

    public async Task<IEnumerable<ProductForMainView>> GetBySortBrandName(int languageId,
        PaginationParams @params, string BrandName)
    {
        switch (languageId)
        {
            case 1:
                var productsEng = _repositoryEng.GetAll().
                    ToPagedListProductEng(@params)
                    .Where(p => p.BrandName == BrandName).
                    ToList();
                var soretedListEng = new List<ProductForMainView>();
                foreach (var item in productsEng)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {
                        id = item.id,
                        ModelName = item.ModelName,
                        BrandName = item.BrandName,
                        GuaranteePeriod = item.GuaranteePeriod,
                        Service = item.Service,
                        MadeIn = item.MadeIn,
                        Produced = item.Produced,
                        ExtraDevices = item.ExtraDevices,
                        PaymentContract = item.PaymentContract,
                        PaymentType = item.PaymentType,
                        FileName = image.FileName,
                        FilePath = image.FilePath,
                    };

                    soretedListEng.Add(productEng);
                }
                return soretedListEng;
                break;
            case 2:
                var productsRus = _repositoryEng.GetAll().
                    ToPagedListProductEng(@params)
                    .Where(p => p.BrandName == BrandName).
                    ToList();
                var soretedListRus = new List<ProductForMainView>();

                foreach (var item in productsRus)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {
                        id = item.id,
                        ModelName = item.ModelName,
                        BrandName = item.BrandName,
                        GuaranteePeriod = item.GuaranteePeriod,
                        Service = item.Service,
                        MadeIn = item.MadeIn,
                        Produced = item.Produced,
                        ExtraDevices = item.ExtraDevices,
                        PaymentContract = item.PaymentContract,
                        PaymentType = item.PaymentType,
                        FileName = image.FileName,
                        FilePath = image.FilePath
                    };

                    soretedListRus.Add(productEng);
                }
                return soretedListRus;
                break;
            case 3:
                var productsUzb = _repositoryEng.GetAll().
                     ToPagedListProductEng(@params)
                     .Where(p => p.BrandName == BrandName).
                     ToList();

                var soretedListUzb = new List<ProductForMainView>();
                foreach (var item in productsUzb)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {   
                        id = item.id,
                        ModelName = item.ModelName,
                        BrandName = item.BrandName,
                        GuaranteePeriod = item.GuaranteePeriod,
                        Service = item.Service,
                        MadeIn = item.MadeIn,
                        Produced = item.Produced,
                        ExtraDevices = item.ExtraDevices,
                        PaymentContract = item.PaymentContract,
                        PaymentType = item.PaymentType,
                        FileName = image.FileName,
                        FilePath = image.FilePath
                    };

                    soretedListUzb.Add(productEng);
                }
                return soretedListUzb;
                break;
            default:
                throw new CustomException(404, "Data not found!");
                break;
        }
    }

    public async Task<bool> UpdateAsync(int languageId,
        ProductForUpdate updateProduct,
        CancellationToken cancellationToken)
    {
        

        switch (languageId)
        {
            case 1:
                var productEng = await _repositoryEng.GetAsync(p => p.ModelName == updateProduct.ModelName);
                if (productEng is null)
                {
                    throw new CustomException(404, "Product not found!");
                }
                
                var mappedEng = _mapper.Map<ProductEng>(updateProduct);
                mappedEng.id = productEng.id;
                await _repositoryEng.UpdateAsync(mappedEng);
                await _repositoryEng.SaveChangesAsync(cancellationToken);
                return true;
                break;
            case 2:
                var productRus = await _repositoryRus.GetAsync(p => p.ModelName == updateProduct.ModelName);
                if (productRus is null)
                {
                    throw new CustomException(404, "Product not found!");
                }
                var mappedRu = _mapper.Map<ProductRus>(updateProduct);
                mappedRu.id = productRus.id;
                await _repositoryRus.UpdateAsync(mappedRu);
                await _repositoryRus.SaveChangesAsync(cancellationToken);
                return true;
                break;
            case 3:
                var productUzb = await _repositoryUzb.GetAsync(p => p.ModelName == updateProduct.ModelName);

                if (productUzb is null)
                {
                    throw new CustomException(404, "Product not found!");
                }
                var mappedUz = _mapper.Map<ProductUzb>(updateProduct);
                mappedUz.id = productUzb.id;
                await _repositoryUzb.UpdateAsync(mappedUz);
                await _repositoryUzb.SaveChangesAsync(cancellationToken);
                return true;
                break;
            default:
                throw new CustomException(404, "Unknown index language");
                break;
        }
    }

    
    
}
