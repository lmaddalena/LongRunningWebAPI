namespace LongRunningWebAPI.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly ILogger<OrderRepository> _logger;
    public OrderRepository(ILogger<OrderRepository> logger)
    {
        _logger = logger;
    }
    public void UpdateOrder(string orderId)
    {
        _logger.LogInformation($"Update Order: {orderId}");
    }
}