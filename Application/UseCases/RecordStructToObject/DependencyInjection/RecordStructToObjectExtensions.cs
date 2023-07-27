using Application.UseCases.RecordStructToObject.Models;
using Application.UseCases.RecordStructToObject.UseCase;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.RecordStructToObject.DependencyInjection;

public static class RecordStructToObjectExtensions
{
    public static IServiceCollection AddRecordStructToObject(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IRequestHandler<RecordStructToObjectInput, RecordStructToObjectOutput>,
                RecordStructToObjectUseCase>();
        
        return serviceCollection;
    }
}