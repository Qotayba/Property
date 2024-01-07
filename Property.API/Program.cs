
using Property.Domain.Interfaces;
using Property.Domain.Services;
using Property.Infrastructure.DbContexts;
using Property.Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;

namespace Property.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
             .WriteTo.Console()
             .CreateLogger();
            var builder = WebApplication.CreateBuilder(args);


            builder.Host.UseSerilog();

            builder.Services.AddLogging();

            builder.Services.AddControllers();
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DatabaseContext>();
            
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
            builder.Services.AddScoped<IApparmentRepository,AppartmentRepository>();
            
            
            builder.Services.AddScoped<IUserServices,UserServices>();
            builder.Services.AddScoped<IPropertyService,PropertyService>();
            builder.Services.AddScoped<IAppatmentService,AppartmentService>();
            builder.Services.AddScoped<AuthecationService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Authentication:Issuer"],
                        ValidAudience = builder.Configuration["Authentication:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
                    };
                }
                );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.Use(async (context, next) =>
            {
                app.Logger.LogInformation("hello");
                await next.Invoke(context);
            }
            );
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }

}