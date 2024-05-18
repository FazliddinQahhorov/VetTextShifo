using System.Linq.Expressions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Application.DTOs.Users.Customer;
using VetTextShifo.Domain.Entities;
using VetTextShifo.Application.DTOs.Products.ForRequest;
using VetTextShifo.Application.DTOs.Products.ForView;
using VetTextShifo.Domain.Entities.ProductDetails.Products;

namespace VetTextShifo.Application.Interfaces;

public interface IProductService
{
    public Task<ProductByIdView> CreatAsync(int languageId, ProductForCreate userCreation, CancellationToken cancellationToken);
    public Task<bool> UpdateAsync(int languageId, ProductForUpdate productForUpdate, CancellationToken cancellationToken);
    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    public Task<ProductByIdView> GetAsync(int languageId, Expression<Func<ProductEng, bool>>? expressionEng = null,
           Expression<Func<ProductRus, bool>>? expressionRus = null,
           Expression<Func<ProductUzb, bool>>? expressionUzb = null);
    public Task<IEnumerable<ProductForMainView>> GetAllAsync(int languageId, PaginationParams @params);
    public Task<IEnumerable<ProductForMainView>> GetBySortBrandName(int languageId,
           PaginationParams @params,
           string BrandName);
    //public Task<ProductForMainView> GetBySortModelName(int languageId,
    //       PaginationParams @params,
    //       string BrandName);


}
