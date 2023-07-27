using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.Liquid.DependencyInjection;
using Application.UseCases.RecordStructToObject.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IHashService, HashService>();
        
        serviceCollection.AddLiquid();
        serviceCollection.AddRecordStructToObject();
        return serviceCollection;
    }
}