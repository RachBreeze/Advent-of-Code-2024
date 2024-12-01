using Day1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddTransient<IReadLocations, ReadLocations>();
builder.Services.AddTransient<IProcessLocations, ProcessLocations>();

using IHost host = builder.Build();
FindHistorian(host.Services);
await host.RunAsync();

static void FindHistorian(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    var provider = serviceScope.ServiceProvider;
    var readLocations = provider.GetRequiredService<IReadLocations>();
    var processLocations = provider.GetRequiredService<IProcessLocations>();

    var locations = readLocations.ReadLocationsFromFile("C:\\GitHub\\Advent-Of-Code-2024\\Day1\\data\\input.txt");
    Console.Write("Locations Found:" + locations.Count());

    var distance = processLocations.TotalDistance(locations);

    Console.Write("Distance:" + distance);
}