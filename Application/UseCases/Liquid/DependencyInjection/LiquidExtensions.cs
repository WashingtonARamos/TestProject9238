using Application.UseCases.Liquid.Models;
using Application.UseCases.Liquid.UseCase;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Liquid.DependencyInjection;

public static class LiquidExtensions
{
    public static IServiceCollection AddLiquid(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IRequestHandler<LiquidInput, LiquidOutput>, LiquidUseCase>();
        return serviceCollection;
    }
}