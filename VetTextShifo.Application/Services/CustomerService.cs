using AutoMapper;
using System.Linq.Expressions;
using System.Threading;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Customer.ForRequest;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Extansions;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Entities.ProductDetails.Products;
using VetTextShifo.Domain.Entities.Users;

namespace VetTextShifo.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IGenericRepository<Customer> _repository;
    private readonly IGenericRepository<ProductUzb> _repositoryProduct;
    private readonly IMapper _mapper;

    public CustomerService(IMapper mapper, IGenericRepository<ProductUzb> repositoryProduct,
        IGenericRepository<Customer> repository)
    {
        _mapper = mapper;
        _repositoryProduct = repositoryProduct;
        _repository = repository;
    }


    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _repository.GetAsync(p => p.id == id);
        if(user is null)
        {
            throw new CustomException(404, "User not exist!");
        }

        await _repository.DeleteAsync(p => p.id == id);
        await _repository.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<IEnumerable<CustomerForView>> GetAllAsync(PaginationParams @params)
    {
        var result = _repository.GetAll().
                     ToPagedListCustomer(@params);
        return  _mapper.Map<IEnumerable<CustomerForView>>(result);
    }

    public async Task<CustomerForView> GetAsync(Expression<Func<Customer, bool>> expression)
    {
        var user = await _repository.GetAsync(expression);
        return _mapper.Map<CustomerForView>(user);
    }

    public async Task<CustomerForView> UpdateAsync(CustomerForUpdateRequest request,
        CancellationToken cancellation)
    {
        var user = await _repository.GetAsync(p => p.id == request.id);
        if (user is  null)
        {
            throw new CustomException(404, "User not found!");
        }

        var result = await _repository.UpdateAsync(_mapper.Map<Customer>(request));
        await _repository.SaveChangesAsync(cancellation);

        return _mapper.Map<CustomerForView>(result);
    }
}
