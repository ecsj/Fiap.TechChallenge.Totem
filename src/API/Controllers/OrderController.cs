﻿using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderUseCase _orderUseCase;

    public OrderController(IOrderUseCase orderUseCase)
    {
        _orderUseCase = orderUseCase;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Order>> Get()
    {
        var orders = _orderUseCase.Get();

        return Ok(orders);
    }
    [HttpGet("GetOrdersByStatus/{status}")]
    public ActionResult<IEnumerable<Order>> GetOrdersByStatus(OrderStatus status)
    {
        var orders = _orderUseCase.GetOrdersByStatus(status);

        return Ok(orders);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var order = await _orderUseCase.GetById(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpGet("GetOrdersByCustomer/{id:Guid}")]
    public IActionResult GetOrdersByCustomer(Guid id)
    {
        var order = _orderUseCase.GetOrdersByCustomer(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpGet("GetByCustomerCpf/{cpf}")]
    public async Task<IActionResult> GetByCustomerCpf(string cpf)
    {
        var orders = await _orderUseCase.GetOrdersByCpf(cpf);

        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderRequest request)
    {
        var order = await _orderUseCase.PlaceOrder(request);

        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }
    
    [HttpPut("UpdateOrderStatus/{id:Guid}")]
    public async Task<IActionResult> UpdateOrderStatus(Guid id, [FromBody] OrderStatus newStatus)
    {
        await _orderUseCase.UpdateOrderStatus(id, newStatus);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelOrder(Guid id)
    {
        await _orderUseCase.CancelOrder(id);

        return NoContent();
    }
}