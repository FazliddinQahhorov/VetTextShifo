using System.Linq.Expressions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Products.Comments;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Application.DTOs.Users.Customer;
using VetTextShifo.Domain.Entities;
using VetTextShifo.Domain.Entities.ProductDetails;

namespace VetTextShifo.Application.Interfaces;

public interface ICommentService
{
    public Task<Comment> CreatAsync(CommentForCreate dto, CancellationToken cancellationToken);
    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    public Task<Comment> GetAsync(Expression<Func<Comment, bool>> expression);
    public Task<IEnumerable<Comment>> GetAllAsync(PaginationParams @params);
}
