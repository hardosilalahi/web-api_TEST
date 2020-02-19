using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.IO;


namespace web_test_api.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next){
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context){

            if(context.Request.Headers["Authorization"] == "hello"){
                
                var startTime = DateTime.Now;
                
                await _next(context);

                var endTime = DateTime.Now - startTime;

                Logger.SaveAllLog(context.Response.StatusCode.ToString(), context.Request.Method.ToString(),endTime.TotalMilliseconds.ToString(), context.Request.Path.ToString(),context.Request.Host.ToString());
            }
            else{
                
                var startTime = DateTime.Now;
                Logger.PopulateLog("Someone tried to access");

                var text = "takbisa";

                var data = System.Text.Encoding.UTF8.GetBytes(text);
                await context.Response.Body.WriteAsync(data, 0, data.Length);

                var endTime = DateTime.Now - startTime;
                Logger.SaveAllLog(context.Response.StatusCode.ToString(), context.Request.Method.ToString(), endTime.TotalMilliseconds.ToString(), context.Request.Path.ToString(), context.Request.Host.ToString());
            }

        }
    }
    
    public static class AuthMiddlewareExtension{
        public static IApplicationBuilder UseAuth(this IApplicationBuilder builder){
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }

    public class Logger{
        public static string Message;
        
        public static void SaveAllLog(string statusCode, string httpMethod, string Time, string httpAddress, string requestPath )
        {
            File.AppendAllText(@"/Users/user/webapi_tutorial/web-test-api/app.log", $"[{DateTime.Now}] Started {httpMethod} {requestPath} for {httpAddress}  \n");
            File.AppendAllText(@"/Users/user/webapi_tutorial/web-test-api/app.log", $"[{DateTime.Now}] Completed {statusCode} on {httpAddress}{requestPath} in {Time}  \n");
        }

        public static void PopulateLog(string message)
        {
           
            Message = message;
        }
    }
}