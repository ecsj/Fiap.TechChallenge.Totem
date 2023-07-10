using Domain.Entities;

namespace Domain.Repositories.Base;

public interface IOrderRepository : IRepository<Order>
{
    List<Order> GetOrdersByCustomerId(Guid customerId);
    Task<List<Order>> GetOrdersByCpf(string cpf);
}