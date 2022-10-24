using InterviewQuestion.API.Extensions;
using InterviewQuestion.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace InterviewQuestion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var configuration = builder.Configuration;


            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Terminal Transaction", Version = "v1" });                
            });

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            builder.Services.AddCors();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.RegisterRepositories();
            builder.Services.RegisterServices();
            builder.Services.RegisterDatabase(configuration);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.RegisterFluentValidators();
            var app = builder.Build();
             
            Seed.SeedDatabase(app);


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
    public static class Seed
    {
        public static void SeedDatabase(WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                SeedDatabase(scope);
            }
            Console.WriteLine("Done seeding database.");
        }
        public static void SeedDatabase(IServiceScope serviceScope)
        {
            try
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();

                var entities = TerminalTransactionData.GetData();
                foreach(var entity in entities)
                {
                    entity.Id = 0;
                }
                context.TerminalTransactions.AddRange(entities);
                //context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}