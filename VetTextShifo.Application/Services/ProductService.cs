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
using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.ProductDetails.Products;

namespace VetTextShifo.Application.Services;

public class ProductService : IProductService
{
    private readonly IGenericRepository<ProductEng> _repositoryEng;
    private readonly IGenericRepository<ProductRus> _repositoryRus;
    private readonly IGenericRepository<ProductUzb> _repositoryUzb;
    private readonly IGenericRepository<Category> _categoryRepository;
    private readonly IGenericRepository<Comment> _commentRepository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public ProductService(IGenericRepository<ProductEng> repositoryEng,
        IGenericRepository<ProductRus> repositoryRus,
        IGenericRepository<ProductUzb> repositoryUzb,
        IMapper mapper,
        IFileService fileService,
        IGenericRepository<Category> categoryRepository,
        IGenericRepository<Comment> commentRepository)
    {
        _repositoryEng = repositoryEng;
        _repositoryRus = repositoryRus;
        _repositoryUzb = repositoryUzb;
        _mapper = mapper;
        _fileService = fileService;
        _categoryRepository = categoryRepository;
        _commentRepository = commentRepository;
    }


    public async Task<ProductByIdView> CreatAsync(int languageId,
        ProductForCreate productCreation,
        CancellationToken cancellationToken)
    {
        switch (languageId)
        {
            case 1:
                var productEng = await _repositoryEng.GetAsync(p => p.ModelName == productCreation.ModelName);
                var category = _categoryRepository.GetAll().Where(p => p.Name == productCreation.BrandName);
                if (category is null)
                {
                    await _categoryRepository.CreateAsync(new Category
                    {
                        Name = productCreation.BrandName
                    });
                }
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

        return true;
    }



    public async Task<IEnumerable<ProductForMainView>> GetAllAsync(int languageId
        , PaginationParams @params)
    {
        switch (languageId)
        {
            case 1:
                var productsEng = _repositoryEng.GetAll().
                    ToPagedListProductEng(@params);
                var soretedListEng = new List<ProductForMainView>();
                foreach (var item in productsEng)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {
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
                   ToPagedListProductEng(@params);
                var soretedListRus = new List<ProductForMainView>();

                foreach (var item in productsRus)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {
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
                   ToPagedListProductEng(@params);
                var soretedListUzb = new List<ProductForMainView>();

                foreach (var item in productsUzb)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {
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
                return mapEn;
                break;
            case 2:
                var mapRu = _mapper.Map<ProductByIdView>(await _repositoryEng.GetAsync(expressionEng));
                mapRu.comments = await _commentRepository.GetAll().Where(p => p.ProductModel == mapRu.ModelName).ToListAsync();
                mapRu.Files = await _fileService.GetForByIdImage(mapRu.id, languageId);
                return mapRu;
                break;
            case 3:
                var mapUz = _mapper.Map<ProductByIdView>(await _repositoryEng.GetAsync(expressionEng));
                mapUz.comments = await _commentRepository.GetAll().Where(p => p.ProductModel == mapUz.ModelName).ToListAsync();
                mapUz.Files = await _fileService.GetForByIdImage(mapUz.id, languageId);
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
                    .Where(p => p.BrandName == BrandName);
                var soretedListEng = new List<ProductForMainView>();
                foreach (var item in productsEng)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {
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
                    .Where(p => p.BrandName == BrandName);
                var soretedListRus = new List<ProductForMainView>();

                foreach (var item in productsRus)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {
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
                     .Where(p => p.BrandName == BrandName);

                var soretedListUzb = new List<ProductForMainView>();
                foreach (var item in productsUzb)
                {
                    var image = await _fileService.GetForMainPageImage(item.id, languageId);

                    var productEng = new ProductForMainView
                    {
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
        var productEng = await _repositoryEng.GetAsync(p => p.ModelName == updateProduct.ModelName);
        var productRus = await _repositoryRus.GetAsync(p => p.ModelName == updateProduct.ModelName);
        var productUzb = await _repositoryUzb.GetAsync(p => p.ModelName == updateProduct.ModelName);
        if (productEng is not null || productRus is not null || productUzb is not null)
        {
            throw new CustomException(400, "Product already exsist!");
        }

        switch (languageId)
        {
            case 1:
                var mappedEng = await _repositoryEng.UpdateAsync(_mapper.Map<ProductEng>(updateProduct));
                await _repositoryEng.SaveChangesAsync(cancellationToken);
                return true;
                break;
            case 2:
                var mappedRus = await _repositoryRus.UpdateAsync(_mapper.Map<ProductRus>(updateProduct));
                await _repositoryRus.SaveChangesAsync(cancellationToken);
                return true;
                break;
            case 3:
                var mappedUzb = await _repositoryEng.UpdateAsync(_mapper.Map<ProductEng>(updateProduct));
                await _repositoryUzb.SaveChangesAsync(cancellationToken);
                return true;
                break;
            default:
                throw new CustomException(404, "Unknown index language");
                break;
        }
    }
}
