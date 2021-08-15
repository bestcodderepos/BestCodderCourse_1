using BestCodder.Common;
using BestCodderCourse.Client.Service.Contracts;
using BestCodderCourse.Client.Service.Implements;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BestCodderCourse.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(ResultConstant.BaseApiUrl) });
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ICourseOrderInfoService, CourseOrderInfoService>();

            await builder.Build().RunAsync();
        }
    }
}
