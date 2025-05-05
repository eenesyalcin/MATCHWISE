using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchwiseServer.Application.Abstractions.Token;
using MatchwiseServer.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace MatchwiseServer.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
