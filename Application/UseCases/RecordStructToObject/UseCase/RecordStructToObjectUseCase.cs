using System.Text.Json;
using Application.Services.Interfaces;
using Application.Templates.Records;
using Application.UseCases.RecordStructToObject.Models;
using MediatR;

namespace Application.UseCases.RecordStructToObject.UseCase;

public class RecordStructToObjectUseCase : IRequestHandler<RecordStructToObjectInput, RecordStructToObjectOutput>
{
    private static readonly JsonSerializerOptions SerializerOptions;
    private readonly IHashService _hashService;

    static RecordStructToObjectUseCase()
    {
        SerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
    
    public RecordStructToObjectUseCase(IHashService hashService)
    {
        _hashService = hashService;
    }

    public Task<RecordStructToObjectOutput> Handle(RecordStructToObjectInput request, CancellationToken cancellationToken)
    {
        var hash = _hashService.GetHash(request.ClientId);

        var rendered = new ClientHash(request.ClientId, hash);

        var res = new RecordStructToObjectOutput()
        {
            Body = JsonSerializer.Serialize(rendered, SerializerOptions)
        };
        
        return Task.FromResult(res);
    }
}