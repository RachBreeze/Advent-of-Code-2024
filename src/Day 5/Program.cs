﻿using FileParse;
using Microsoft.Extensions.DependencyInjection;
namespace Day5;


internal class Program
{
    private static IServiceProvider _serviceProvider;

    public static void Main(string[] args)
    {
        RegisterServices();
        IServiceScope scope = _serviceProvider.CreateScope();
        scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();
    }

    private static void RegisterServices()
    {
        var services = new ServiceCollection();
        services.AddTransient<IReadFileContents, ReadFileContents>();
        services.AddTransient<IParser, Parser>();
        services.AddSingleton<ConsoleApplication>();
        _serviceProvider = services.BuildServiceProvider(true);
    }
}
