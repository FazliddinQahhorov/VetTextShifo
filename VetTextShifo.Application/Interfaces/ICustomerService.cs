using System.Linq.Expressions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Customer.ForRequest;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Domain.Entities.Users;

namespace VetTextShifo.Application.Interfaces;

public interface ICustomerService
{
    public Task<CustomerForView> UpdateAsync(CustomerForUpdateRequest request,
        CancellationToken cancellation);
    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    public Task<CustomerForView> GetAsync(Expression<Func<Customer,bool>> expression);
    public Task<IEnumerable<CustomerForView>> GetAllAsync(PaginationParams @params);
}
