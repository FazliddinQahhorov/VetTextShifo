using System.Linq.Expressions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Products.ForRequest;
using VetTextShifo.Application.DTOs.Products.ForView;
using VetTextShifo.Application.DTOs.Users.News.ForRequests;
using VetTextShifo.Application.DTOs.Users.News.ForResponse;
using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.ProductDetails.NewsModel;
using VetTextShifo.Domain.Entities.ProductDetails.Products;

namespace VetTextShifo.Application.Interfaces;

public interface INewsService
{
    public Task<NewsForResponce> CreatAsync(int languageId, NewsForRequest userCreation, CancellationToken cancellationToken);
    public Task<bool> UpdateAsync(int languageId, NewsForRequest userPasswordChange, CancellationToken cancellationToken);
    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    public Task<NewsForResponce> GetAsync(int languageId, Expression<Func<NewsModelEng, bool>>? expressionEng = null,
           Expression<Func<NewsModelRus, bool>>? expressionRus = null,
           Expression<Func<NewsModelUzb, bool>>? expressionUzb = null);
    public Task<IEnumerable<NewsForResponce>> GetAllAsync(int languageId, PaginationParams @params);
}
