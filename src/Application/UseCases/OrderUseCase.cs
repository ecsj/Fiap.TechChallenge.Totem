using Application.Interfaces;
using Domain.Base;
using Domain.Entities;
using Domain.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace Application.UseCases;

public class OrderUseCase : IOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IRepository<Product> _productRepository;
    private readonly IClientUseCase _clientUseCase;
    private readonly ILogger<OrderUseCase> _logger;

    public OrderUseCase(IOrderRepository orderRepository,
                        IRepository<Product> productRepository,
                        IClientUseCase clientUseCase,
                        ILogger<OrderUseCase> logger)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _clientUseCase = clientUseCase;
        _logger = logger;
    }

    public async Task<Order> PlaceOrder(OrderRequest request)
    {
        try
        {
            var order = Order.FromOrderRequest(request);

            foreach (var item in order.Products)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);

                if (product is null)
                    throw new DomainException("Produto não encontrado");

            }           

            //if (!string.IsNullOrEmpty(request.ClientId))
            //{
            //    var client = await _clientUseCase.GetById(Guid.Parse(request.ClientId));

            //    if (client is not null)
            //        order.ClientId = Guid.Parse(request.ClientId);
            //}

            await _orderRepository.AddAsync(order);

            return order;
        }
        catch (Exception ex)
        {
            _logger.LogError("Erro ao criar Pedido", ex);
            throw;
        }
    }

    public IQueryable<Order> Get()
    {
        return _orderRepository.Get();
    }
    public IList<Order> GetOrdersByStatus(OrderStatus status)
    {
        return _orderRepository.Get().Where(o => o.Status == status).ToList();
    }
    public IList<Order> GetOrdersPending()
    {
        return _orderRepository.Get().Where(o => o.Status == OrderStatus.Pending).ToList();
    }

    public List<Order> GetOrdersByCustomer(Guid customerId)
    {
        return _orderRepository.GetOrdersByCustomerId(customerId);
    }

    public async Task<List<Order>> GetOrdersByCpf(string cpf)
    {
        return await _orderRepository.GetOrdersByCpf(cpf);
    }
    public async Task<Order> GetById(Guid orderId)
    {
        return await _orderRepository.GetByIdAsync(orderId);
    }

    public async Task UpdateOrderStatus(Guid orderId, OrderStatus newStatus)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order != null)
        {
            order.Status = newStatus;
            await _orderRepository.UpdateAsync(order);
        }
    }

    public async Task CancelOrder(Guid orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order != null)
        {
            order.Status = OrderStatus.Canceled;
            _orderRepository.UpdateAsync(order);
        }
    }
}