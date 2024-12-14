using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace leave_a_comment_api.ActionFilter
{
 
    public class ApiKeyAuthAttribute : ActionFilterAttribute
    {
        private readonly string _apiKeyHeaderName;
        private readonly string _apiKey;

        public ApiKeyAuthAttribute(IConfiguration configuration)
        {
            _apiKeyHeaderName = configuration["Swagger:ApiKeyHeaderName"];
            _apiKey = configuration["ApiKey"];
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(_apiKeyHeaderName, out var extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!_apiKey.Equals(extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
