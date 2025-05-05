
using System.Text;
using MatchwiseServer.Application;
using MatchwiseServer.Infrastructure.Filters;
using MatchwiseServer.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MatchwiseServer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // IConfiguration ile ortam deðiþkenini kullan
            var configuration = builder.Configuration;

            // Persistence servislerini ekle
            builder.Services.AddPersistenceServices(configuration);
            builder.Services.AddApplicationServices();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy
                        .WithOrigins("http://localhost:4200", "https://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        // Oluþturulacak token deðerini kimlerin, hangi sitelerin kullanacaðýný belirlediðimiz deðerdir.    --> www.bilmemne.com
                        ValidateAudience = true,
                        // Oluþturulacak token deðerini kimin daðýttýðýný ifade edeceðimiz alandýr.                         --> www.myapi.com
                        ValidateIssuer = true,
                        // Oluþturulan token deðerinin süresini kontrol edecek olan doðrulamadýr.
                        ValidateLifetime = true,
                        // Üretilecek token deðerinin uygulamamýza ait bir deðer olduðunu ifade eden security key deðerinin doðrulanmasýdýr.
                        ValidateIssuerSigningKey = true,

                        ValidAudience = builder.Configuration["Token:Audience"],
                        ValidIssuer = builder.Configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
