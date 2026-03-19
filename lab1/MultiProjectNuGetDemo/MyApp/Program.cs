using MyLibrary;
using Newtonsoft.Json;
using MyServices;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
        .AddSingleton<ILoggerService, ConsoleLogger>()
        .BuildServiceProvider();

        var logger = serviceProvider.GetRequiredService<ILoggerService>();
        
        Calculator calc = new Calculator();

        int sum = calc.Add(5, 3);
        int difference = calc.Subtract(45, 16);

        var result = new { Operation = "Add", A = 5, B = 3, Result = sum };

        string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);

        logger.Log(jsonResult);

        logger.Log($"Suma: {sum}");
        logger.Log($"Różnica: {difference}");
    }
}