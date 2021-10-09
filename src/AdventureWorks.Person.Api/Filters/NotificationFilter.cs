using AdventureWorks.Person.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Person.Api.Filters
{
    public sealed class NotificationFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var objectResult = context.Result as ObjectResult;

            if (objectResult?.Value is Notification notification && notification.ValidationMessages.Any())
            {
                context.Result = new BadRequestObjectResult(notification);
            }

            await next();
        }
    }
}
