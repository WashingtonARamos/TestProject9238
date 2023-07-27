using Application.Services.Interfaces;
using Application.UseCases.Liquid.Models;
using DotLiquid;
using MediatR;

namespace Application.UseCases.Liquid.UseCase;

public class LiquidUseCase : IRequestHandler<LiquidInput, LiquidOutput>
{
    private readonly IHashService _hashService;
    
    public LiquidUseCase(IHashService hashService)
    {
        _hashService = hashService;
    }
    
    public Task<LiquidOutput> Handle(LiquidInput request, CancellationToken cancellationToken)
    {
        const string liquidTemplate = """
            {
                "clientId" : "{{ clientId }}",
                "hash": "{{ hash }}"
            }
            """;

        var hash = _hashService.GetHash(request.ClientId);

        var template = Template.Parse(liquidTemplate);

        return Task.FromResult(new LiquidOutput()
        {
            Body = template.Render(Hash.FromAnonymousObject(
                new
                {
                    clientId = request.ClientId,
                    hash
                }))
        });
    }
}