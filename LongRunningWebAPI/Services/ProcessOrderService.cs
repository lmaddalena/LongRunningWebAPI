namespace LongRunningWebAPI.Services;

public class ProcessOrderService 
{
    private readonly ILogger<ProcessOrderService> _logger;
    private readonly Repository.IOrderRepository _orderRepository;

    public ProcessOrderService(ILogger<ProcessOrderService> logger, Repository.IOrderRepository orderRepository)
    {
        _logger = logger;
        _orderRepository = orderRepository;
    }
    public void Execute(string orderId)
    {
        
        Task.Run(async () => {
            _logger.LogInformation($"ProcessOrderService: ThreadId: {System.Threading.Thread.CurrentThread.ManagedThreadId} OrderId {orderId} - Starting at {DateTime.UtcNow.TimeOfDay}");

            await Task.Delay(60000);
            _orderRepository.UpdateOrder(orderId);
            _logger.LogInformation($"ProcessOrderService: ThreadId: {System.Threading.Thread.CurrentThread.ManagedThreadId} OrderId {orderId} -  Done at {DateTime.UtcNow.TimeOfDay}");

        });
        

        //Task.Run(() => ExecuteAsync(orderId));

    }
    
    private async void ExecuteAsync(string orderId)
    {
            _logger.LogInformation($"ProcessOrderService: ThreadId: {System.Threading.Thread.CurrentThread.ManagedThreadId} OrderId {orderId} - Starting at {DateTime.UtcNow.TimeOfDay}");

            await Task.Delay(60000);
            _orderRepository.UpdateOrder(orderId);
            _logger.LogInformation($"ProcessOrderService: ThreadId: {System.Threading.Thread.CurrentThread.ManagedThreadId} OrderId {orderId} -  Done at {DateTime.UtcNow.TimeOfDay}");

    }
}