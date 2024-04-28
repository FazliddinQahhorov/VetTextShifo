using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Products.Comments;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Extansions;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Entities;
using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.ProductDetails.Products;

namespace VetTextShifo.Application.Services;

public class CommentService : ICommentService
{
    private readonly IGenericRepository<Comment> _repository;
    

    private readonly IMapper _mapper;
    public CommentService(IGenericRepository<Comment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Comment> CreatAsync(CommentForCreate dto, CancellationToken cancellationToken)
    {
        var result = await _repository.CreateAsync(_mapper.Map<Comment>(dto));
        await _repository.SaveChangesAsync(cancellationToken);
       
        return result;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetAsync(p => p.id == id);
        if(comment is null)
        {
            throw new CustomException(404, "Unknown comment!");
        }
        var result = await _repository.DeleteAsync(p => p.id == id);
        await _repository.SaveChangesAsync(cancellationToken);
        return result;
    }

    public Task<IEnumerable<Comment>> GetAllAsync(PaginationParams @params)
    {
        var comments = _repository.GetAll()
                          .ToPagedListComments(@params);
        return (Task<IEnumerable<Comment>>)comments;
    }

    public async Task<Comment> GetAsync(Expression<Func<Comment, bool>> expression)
    {
        var result = await _repository.GetAsync(expression);
        return result;
    }

    //public async Task<bool> UpdateAsync(CommentForCreate dto, CancellationToken cancellationToken)
    //{
    //    var result = await _repository.UpdateAsync(_mapper.Map<Comment>(dto));
    //    await _repository.SaveChangesAsync(cancellationToken);
    //    return true;
    //}
}
