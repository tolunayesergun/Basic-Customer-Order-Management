using Core.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace Core.AOP
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var methodName = context.ActionDescriptor.DisplayName;
            Console.WriteLine($"Metod Başlangıcı: {methodName}");
            Log.Info($"Parametre: {methodName}");

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var methodName = context.ActionDescriptor.DisplayName;
            var returnValue = context.Result;
            Console.WriteLine($"Metod Çıkışı: {methodName} | Return = {returnValue}");
            Log.Info($"Metod Çıkışı: {methodName} | Return = {returnValue}");

            base.OnActionExecuted(context);
        }
    }
}
