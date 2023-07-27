using MediatR;

namespace Application.UseCases.RecordStructToObject.Models;

public class RecordStructToObjectInput : IRequest<RecordStructToObjectOutput>
{
    public string ClientId { get; set; }
}