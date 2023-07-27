using Application.Services;
using Application.Services.Interfaces;
using Application.UseCases.Liquid.Models;
using Application.UseCases.Liquid.UseCase;
using Application.UseCases.RecordStructToObject.Models;
using Application.UseCases.RecordStructToObject.UseCase;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] _)
    {
        BenchmarkRunner.Run(typeof(Tests));
    }

    [MemoryDiagnoser]
    public class Tests
    {
        private IHashService _hashService;
        private LiquidUseCase _liquidUseCase;
        private RecordStructToObjectUseCase _recordStructToObjectUseCase;
        
        [GlobalSetup]
        public void Initialize()
        {
            _hashService = new HashService();
            _liquidUseCase = new LiquidUseCase(_hashService);
            _recordStructToObjectUseCase = new RecordStructToObjectUseCase(_hashService);
        }
        
        [Benchmark]
        public void LiquidBenchmark()
        {
            var randomClientId = _hashService.GetRandomNumberAsString();
            _liquidUseCase.Handle(new LiquidInput()
            {
                ClientId = randomClientId
            }, CancellationToken.None);
        }

        [Benchmark]
        public void RecordStructBrenchMark()
        {
            var randomClientId = _hashService.GetRandomNumberAsString();
            _recordStructToObjectUseCase.Handle(new RecordStructToObjectInput()
            {
                ClientId = randomClientId
            }, CancellationToken.None);
        }
    }
}