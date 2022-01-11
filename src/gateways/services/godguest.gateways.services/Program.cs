using godguest.gateways.services.Version;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Environments = godguest.gateways.services.Version.Environments;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (EnvironmentSettings.Env == Environments.Local)
    builder.Configuration.AddJsonFile("ocelot.json");
else
    builder.Configuration.AddJsonFile("ocelot.docker.json");

builder.Services.AddControllers();
builder.Services.AddOcelot()
    .AddDelegatingHandler<RequestInspector>();


var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseOcelot();

app.MapControllers();

app.Run();

public class RequestInspector : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"\nDevam etmeden önce ?u gelen Request içeri?ini bir inceyelim\n{request.ToString()}\n");
        return await base.SendAsync(request, cancellationToken);
    }
}