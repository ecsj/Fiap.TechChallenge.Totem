using Domain.Entities;
using Domain.Request;

namespace Application.Interfaces;

public interface IOrderUseCase
{
    Task<Order> PlaceOrder(OrderRequest order);
    List<Order> GetOrdersByCustomer(Guid customerId);
    Task<List<Order>> GetOrdersByCpf(string cpf);
    IQueryable<Order> Get();
    Task<Order> GetById(Guid orderId);
    IList<Order> GetOrdersPending();
    IList<Order> GetOrdersByStatus(OrderStatus status);
    Task UpdateOrderStatus(Guid orderId, OrderStatus newStatus);
    Task CancelOrder(Guid orderId);
}