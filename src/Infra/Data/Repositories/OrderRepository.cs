using Domain.Entities;
using Domain.Repositories.Base;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public List<Order> GetOrdersByCustomerId(Guid customerId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Order>> GetOrdersByCpf(string cpf)
    {
        return await _dbContext.Set<Order>().Where(c => c.Client.CPF == cpf).ToListAsync();
    }
}
