using AutoMapper;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.ProductDetails.Products;

namespace VetTextShifo.Application.Services;

public class LikeService : ILikeService
{
    private readonly IGenericRepository<ProductEng> _productEngRepository;
    private readonly IGenericRepository<ProductRus> _productRusRepository;
    private readonly IGenericRepository<ProductUzb> _productUzbRepository;
    private readonly IGenericRepository<Likes> genericRepository;
    public LikeService(IGenericRepository<ProductEng> productEngRepository,
        IGenericRepository<ProductRus> productRusRepository,
        IGenericRepository<ProductUzb> productUzbRepository,
        IGenericRepository<Likes> genericRepository)
    {
        _productEngRepository = productEngRepository;
        _productRusRepository = productRusRepository;
        _productUzbRepository = productUzbRepository;
        this.genericRepository = genericRepository;
    }

    public async Task AddLikeProduct(Likes like, CancellationToken cancellationToken)
    {
        Likes? isLiked = await genericRepository.GetAsync(p => p.ProductModelName == like.ProductModelName && 
                                                            p.CustomerIP == like.CustomerIP);
        var productRus = await _productRusRepository.GetAsync(p => p.ModelName == like.ProductModelName);
        var productEng = await _productEngRepository.GetAsync(p => p.ModelName == like.ProductModelName);
        var productUzb = await _productUzbRepository.GetAsync(p => p.ModelName == like.ProductModelName);
        if (isLiked is not null)
        {
            productEng.LikeCount -= 1;
            productRus.LikeCount -= 1;
            productUzb.LikeCount -= 1;

            await genericRepository.DeleteAsync(p => p.id == like.id);
            await genericRepository.SaveChangesAsync(cancellationToken);
        }

        productEng.LikeCount += 1;
        productRus.LikeCount += 1;
        productUzb.LikeCount += 1;

        await genericRepository.CreateAsync(like);
        await genericRepository.SaveChangesAsync(cancellationToken);
    }

}
