using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using MatchwiseServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MatchwiseServer.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(ServiceRegistration));

            // Application katmanındaki handler’ları tarar:
            services.AddMediatR(typeof(ServiceRegistration).Assembly);

            // PasswordHasher<Company> kaydı:
            services.AddScoped<IPasswordHasher<Company>, PasswordHasher<Company>>();
        }
    }
}
