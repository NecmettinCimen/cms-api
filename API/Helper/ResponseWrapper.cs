using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace cms_api.Helper
{
    public class ResponseWrapper(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            var currentBody = context.Response.Body;
            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;
                try
                {
                    Services.LoggerBackgroundService.istelsayi++;
                    await next(context);

                    context.Response.Body = currentBody;
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    var readToEnd = new StreamReader(memoryStream).ReadToEnd();
                    object objResult = null;
                    if (readToEnd.ValidateJSON())
                    {
                        objResult = JsonConvert.DeserializeObject(readToEnd);
                    }
                    else
                    {
                        objResult = readToEnd;
                    }
                    var result = CommonApiResponse.Create((HttpStatusCode)context.Response.StatusCode, objResult);
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                }
                catch (Exception ex)
                {
                    Services.LoggerBackgroundService.hatasayisi++;

                    Console.WriteLine(ex);
                    context.Response.Body = currentBody;
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    var result = CommonApiResponse.Create(HttpStatusCode.InternalServerError, errorMessage: ex.Message);
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                }
            }
        }
    }
}