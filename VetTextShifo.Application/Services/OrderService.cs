using AutoMapper;
using System.Linq.Expressions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Orders.ForRequest;
using VetTextShifo.Application.DTOs.Users.Orders.ForView;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Extansions;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Entities.Users;

namespace VetTextShifo.Application.Services;

public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IGenericRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;

    public OrderService(IGenericRepository<Order> oderRepository, IMapper mapper,
        IGenericRepository<Customer> customerRepository)
    {
        _orderRepository = oderRepository;
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<OrderForView> CreateOrder(OrderForRequest orderForCreate,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetAsync(p => p.CustomerNumber == orderForCreate.CustomerNumber &&
                                                       p.ProductModelName == orderForCreate.ProductModelName);

        if (order != null)
        {
            throw new CustomException(400, "This order type already exists!");
        }

        // Check if the customer exists
        var result = await _orderRepository.CreateAsync(_mapper.Map<Order>(orderForCreate));
        await _orderRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<OrderForView>(result);
    }

    public async Task<bool> DeleteOrder(int id, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetAsync(p => p.id == id);
        if (order is null)
        {
            throw new CustomException(404, "This Order not found");
        }
        await _orderRepository.DeleteAsync(p => p.id == id);
        await _orderRepository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<OrderForView>> GetAllOrders(PaginationParams @params)
    {
        var orders = _orderRepository.GetAll().
                   ToPagedListOrders(@params);
        return _mapper.Map<IEnumerable<OrderForView>>(orders);
    }

    public async Task<OrderForView> GetOrder(Expression<Func<Order, bool>> order)
    {
        var getOrder = await _orderRepository.GetAsync(order);
        if (getOrder is null)
        {
            throw new CustomException(404, "Order not found!");
        }

        return _mapper.Map<OrderForView>(getOrder);
    }

    public async Task<OrderForView> UpdateOrder(OrderForView orderForUpdate,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetAsync(p => p.id == orderForUpdate.id);
        if (order is  null)
        {
            throw new CustomException(400, "This order not exsist!");
        }
        order.CustomerNumber = orderForUpdate.CustomerNumber;
        order.CustomerName = orderForUpdate.CustomerName;
        order.ProductModelName = orderForUpdate.ProductModelName;
        order.CreatedDate = DateTime.UtcNow;
        var result = await _orderRepository.UpdateAsync(order);
        await _orderRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<OrderForView>(result);
    }
}
