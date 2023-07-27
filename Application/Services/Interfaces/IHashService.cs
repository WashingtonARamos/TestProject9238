namespace Application.Services.Interfaces;

public interface IHashService
{
    public string GetRandomNumberAsString();
    public string GetHash(string input);
}