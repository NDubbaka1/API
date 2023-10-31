using System.Net;

namespace API.Middleware
{
    public class ExpectionHandlerMiddleWare
    {
        private readonly ILogger<ExpectionHandlerMiddleWare> logger;
        private readonly RequestDelegate next;

        public ExpectionHandlerMiddleWare(ILogger<ExpectionHandlerMiddleWare> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid().ToString();
                //logging exception 
                logger.LogError(ex,$"{errorId} :{ex.Message}");


                // return a custom error by using httpcontext
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong. We are looking in to this"

                };
               await httpContext.Response.WriteAsJsonAsync(error);
               
            }
        }
    }
}
