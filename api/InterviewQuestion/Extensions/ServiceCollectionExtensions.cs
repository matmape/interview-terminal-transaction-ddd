using FluentValidation;
using InterviewQuestion.API.Services.Agents;
using InterviewQuestion.API.Services.TerminalTransactions;
using InterviewQuestion.API.Validators;
using InterviewQuestion.Domain.Interfaces;
using InterviewQuestion.Domain.TerminalTransactions;
using InterviewQuestion.Infrastructure.Data;
using InterviewQuestion.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InterviewQuestion.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>))
                .AddScoped<ITerminalTransactionRepository, TerminalTransactionRepository>()
                .AddScoped<IAgentRepository, AgentRepository>();
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ITerminalTransactionService, TerminalTransactionService>() 
                .AddScoped<IAgentService, AgentService>() 
                .AddSingleton<TerminalTransactionData>();
        }
        public static IServiceCollection RegisterFluentValidators(this IServiceCollection services)
        {
            return services
                .AddValidatorsFromAssemblyContaining<TerminalTransactionAddValidator>();
        }
        public static IServiceCollection RegisterDatabase(this IServiceCollection services
           , IConfiguration configuration)
        {
            return services.AddDbContext<ApplicationDbContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
