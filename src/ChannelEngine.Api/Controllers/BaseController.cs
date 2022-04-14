
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChannelEngine.Api.Controllers;

public abstract class BaseController : Controller
{
    private readonly ILogger logger;

    public BaseController(ILogger logger) => this.logger = logger;

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception != null)
        {
            logger.LogError(context.Exception, "exception occured during process request!");
        }

        base.OnActionExecuted(context);
    }
}