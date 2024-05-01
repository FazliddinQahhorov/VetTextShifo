using AutoMapper;
using VetTextShifo.Application.Exceptions;
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
        ProductEng? product = await _productEngRepository.GetAsync(p => p.id == 1);
        Likes? isLiked = await genericRepository.GetAsync(p => p.ProductModelName == like.ProductModelName && 
                                                            p.CustomerIP == like.CustomerIP);
        if( isLiked is null)
        {
            
        }
            
    }

    public Task RemoveLikeProduct(Likes like, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
