using System.Linq.Expressions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Orders.ForRequest;
using VetTextShifo.Application.DTOs.Users.Orders.ForView;
using VetTextShifo.Domain.Entities.Users;

namespace VetTextShifo.Application.Interfaces;

public interface IOrderService
{
    public Task<OrderForView> CreateOrder(OrderForRequest orderForCreate,
        CancellationToken cancellationToken);
    public Task<OrderForView> UpdateOrder(OrderForView orderForUpdate,
        CancellationToken cancellationToken);
    public Task<bool> DeleteOrder(int id,  CancellationToken cancellationToken);
    public Task<OrderForView> GetOrder(Expression<Func<Order,bool>> order);
    public Task<IEnumerable<OrderForView>> GetAllOrders(PaginationParams @params);
}
