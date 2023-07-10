using Domain.Base;

namespace Domain.Entities;

public class Order : Entity, IAggregateRoot
{
    public Client? Client { get; set; }
    public Guid? ClientId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();
    public List<Additional> Additional { get; set; } = new List<Additional>();
    public OrderStatus Status { get; set; }
    public decimal TotalPrice { get; set; }

    public static Order FromOrderRequest(OrderRequest orderRequest)
    {
        var order = new Order
        {
            ClientId = string.IsNullOrEmpty(orderRequest.ClientId) ? null : Guid.Parse(orderRequest.ClientId),
            Status = OrderStatus.Pending,
            Products = new List<OrderProduct>(),
            OrderDate = DateTime.UtcNow
        };

        foreach (var orderProductRequest in orderRequest.Products)
        {
            var product = new OrderProduct
            {
                ProductId = orderProductRequest.ProductId,
                Quantity = orderProductRequest.Quantity,
                Total = orderProductRequest.Total,
                Comments = orderProductRequest.Comments,
                Additional = new List<Additional>()
            };

            foreach (var additionalRequest in orderProductRequest.Additional)
            {
                var additional = new Additional
                {
                    ProductId = additionalRequest.ProductId,
                    Price = additionalRequest.AdditionalPrice
                };
                product.Additional.Add(additional);
            }

            order.Products.Add(product);
        }
        
        order.TotalPrice = orderRequest.Total;        

        return order;
    }

    public void Validate()
    {
        if (Products == null || Products.Count == 0)
        {
            throw new Exception("O pedido não contém nenhum produto.");
        }

        foreach (var product in Products)
        {
            if (product.Quantity <= 0)
            {
                throw new Exception($"A quantidade para o produto '{product.ProductId}' deve ser maior que zero.");
            }
        }

        if (TotalPrice <= 0)
        {
            throw new Exception("O preço total do pedido deve ser maior que zero.");
        }
    }
}