using MediatR;

namespace Application.UseCases.Liquid.Models;

public class LiquidInput : IRequest<LiquidOutput>
{
    public string ClientId { get; set; }
}