using MassTransit;
using TesteB3.Infrasctructure.Logging;
using TesteB3.WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((host,services) =>
    {
        services.AddHostedService<Worker>();
        services.AddMassTransit(host.Configuration); 

    }).Build();
new SerilogInitializer();
await host.RunAsync();


