using BooksAPI.Sdk.Book;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Sdk
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSdkServices(this IServiceCollection services, Action<Options> config)
        {
            services.Configure(config);
            services.AddHttpClient();
            services.AddSingleton<HTTPHelper>();
            //services.AddSingleton<Options>(config);
            services.AddScoped<HttpBookService>();
            return services;
        }
    }
}