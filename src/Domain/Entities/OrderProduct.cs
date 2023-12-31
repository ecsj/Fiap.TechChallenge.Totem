﻿namespace Domain.Entities;

public class OrderProduct
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public string Comments { get; set; }
    public List<Additional> Additional { get; set; }
    public decimal Total { get; internal set; }
}
