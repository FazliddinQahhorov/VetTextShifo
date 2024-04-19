using Newtonsoft.Json;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Domain.Commons;
using VetTextShifo.Domain.Entities;
using VetTextShifo.Domain.Entities.ProductDetails.Products;

namespace VetTextShifo.Application.Extansions;

public static class CollectionsExtension
{
    public static IQueryable<Admin> ToPagedListAdmin(this IQueryable<Admin> source, PaginationParams @params)
    {

        var metaData = new PaginationMetaData(source.Count(), @params);
        var json = JsonConvert.SerializeObject(metaData);

        return @params.PageIndex > 0 && @params.PageSize > 0 ?
        source
            .OrderBy(s => s.id)
            .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
            : throw new CustomException(400, "Please, enter valid numbers");
    }

    public static IQueryable<ProductEng> ToPagedListProductEng(this IQueryable<ProductEng> source, PaginationParams @params)
    {

        var metaData = new PaginationMetaData(source.Count(), @params);
        var json = JsonConvert.SerializeObject(metaData);

        return @params.PageIndex > 0 && @params.PageSize > 0 ?
        source
            .OrderBy(s => s.id)
            .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
            : throw new CustomException(400, "Please, enter valid numbers");
    }
    public static IQueryable<ProductRus> ToPagedListProductRus(this IQueryable<ProductRus> source, PaginationParams @params)
    {

        var metaData = new PaginationMetaData(source.Count(), @params);
        var json = JsonConvert.SerializeObject(metaData);

        return @params.PageIndex > 0 && @params.PageSize > 0 ?
        source
            .OrderBy(s => s.id)
            .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
            : throw new CustomException(400, "Please, enter valid numbers");
    }
    public static IQueryable<ProductUzb> ToPagedListProductUzb(this IQueryable<ProductUzb> source, PaginationParams @params)
    {

        var metaData = new PaginationMetaData(source.Count(), @params);
        var json = JsonConvert.SerializeObject(metaData);

        return @params.PageIndex > 0 && @params.PageSize > 0 ?
        source
            .OrderBy(s => s.id)
            .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
            : throw new CustomException(400, "Please, enter valid numbers");
    }
}
