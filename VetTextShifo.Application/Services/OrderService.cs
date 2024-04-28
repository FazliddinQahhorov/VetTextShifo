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
    private readonly IGenericRepository<Order> _oderRepository;
    private readonly IMapper _mapper;

    public OrderService(IGenericRepository<Order> oderRepository, IMapper mapper)
    {
        _oderRepository = oderRepository;
        _mapper = mapper;
    }

    public async Task<OrderForView> CreateOrder(OrderForRequest orderForCreate, CancellationToken cancellationToken)
    {
        var order = await _oderRepository.GetAsync(p => p.CustomerNumber == orderForCreate.CustomerNumber &&
                                                        p.ProductModelName == orderForCreate.ProductModelName);
        if (order is not null)
        {
            throw new CustomException(400, "This order type already sending!");
        }

        var result = await _oderRepository.CreateAsync(_mapper.Map<Order>(orderForCreate));
        await _oderRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<OrderForView>(result);
    }

    public async Task<bool> DeleteOrder(int id, CancellationToken cancellationToken)
    {
        var order = await _oderRepository.GetAsync(p => p.id == id);
        if (order is null)
        {
            throw new CustomException(404, "This Order not found");
        }
        await _oderRepository.DeleteAsync(p => p.id == id);
        await _oderRepository.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<OrderForView>> GetAllOrders(PaginationParams @params)
    {
        var orders = _oderRepository.GetAll().
                   ToPagedListOrders(@params);
        return _mapper.Map<IEnumerable<OrderForView>>(orders);
    }

    public async Task<OrderForView> GetOrder(Expression<Func<Order, bool>> order)
    {
        var getOrder = await _oderRepository.GetAsync(order);
        if (getOrder is null)
        {
            throw new CustomException(404, "Order not found!");
        }

        return _mapper.Map<OrderForView>(getOrder);
    }

    public async Task<OrderForView> UpdateOrder(int id, OrderForRequest orderForUpdate,
        CancellationToken cancellationToken)
    {
        var order = await _oderRepository.GetAsync(p => p.CustomerNumber == orderForUpdate.CustomerNumber &&
                                                       p.ProductModelName == orderForUpdate.ProductModelName);
        if (order is not null)
        {
            throw new CustomException(400, "This order type already sending!");
        }

        var result = await _oderRepository.UpdateAsync(_mapper.Map<Order>(orderForUpdate));
        await _oderRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<OrderForView>(result);
    }
}
