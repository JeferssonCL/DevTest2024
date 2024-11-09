using Backend.Application.Dtos;
using Backend.Application.Validations;
using Backend.Domain.Concretes;
using Backend.Infrastructure.Repositories.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Application;

public static class ApplicationConfiguration
{
    public static void AddConfigurations(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(ApplicationConfiguration).Assembly));

        services.AddScoped<IValidator<CreatePoolDto>, CreatePoolValidation>();
        services.AddScoped<IValidator<CreateVoteDto>, CreateVoteValidation>();
        services.AddScoped<IRepository<Pool>, PoolRepository>();
        services.AddScoped<IRepository<Vote>, VoteRepository>();
        services.AddScoped<IRepository<Option>, OptionRepository>();
    }
}