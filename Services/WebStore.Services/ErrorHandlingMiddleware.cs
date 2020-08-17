using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebStore.Services
{
    public class ErrorHandlingMiddleware
   {

       private readonly RequestDelegate next;

       private static readonly log4net.ILog Log =
           log4net.LogManager.GetLogger(typeof(ErrorHandlingMiddleware));
       
       public ErrorHandlingMiddleware(RequestDelegate next)
       {
           this.next = next;
       }

       public async Task Invoke(HttpContext context)
       {
           try
           {
               await this.next(context);
           }
           catch (Exception ex)
           {
               await HandleExceptionAsync(context, ex);
               throw;
           }
       }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Log.Error(exception);
            return Task.CompletedTask;
        }
    }
}
