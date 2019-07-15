using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace GameStore.PL.Filters
{
    public class LogIpResourceFilter : IAsyncResourceFilter
    {
        private readonly ILogger<LogIpResourceFilter> _logger;

        public LogIpResourceFilter(ILogger<LogIpResourceFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            _logger.LogInformation($" ***** IP: {context.HttpContext.Connection.RemoteIpAddress} ****** ");
            await next();
        }
    }
}
