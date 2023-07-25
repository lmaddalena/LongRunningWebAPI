using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LongRunningWebAPI.Controllers
{
    /// <summary>
    /// Manage Orders
    /// </summary>
    [Route("api/[controller]/process")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly Services.ProcessOrderService _processOrderService;

        /// <summary>
        /// Default constructor
        /// </summary>
        public OrdersController(
            ILogger<OrdersController> logger, 
            Services.ProcessOrderService processOrderService)
        {
            _logger = logger;
            _processOrderService = processOrderService;
        }

        /// <summary>
        /// Process order
        /// </summary>
        /// <param name="orderId">Order Id to be processed</param>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST api/orders/process
        ///     {
        ///         "orderId": "xyz123"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Order processing is started</response>
        /// <response code="400">OrderId is null</response>
        /// <response code="404">Order Not Found</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody] string orderId)
        {
            _logger.LogInformation($"Order Process: ThreadId: {System.Threading.Thread.CurrentThread.ManagedThreadId}  Starting at {DateTime.UtcNow.TimeOfDay}");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _processOrderService.Execute(Guid.NewGuid().ToString());
            
            _logger.LogInformation($"Order Process: ThreadId: {System.Threading.Thread.CurrentThread.ManagedThreadId} Done at {DateTime.UtcNow.TimeOfDay}");

            return Ok();
        }

    }
}
