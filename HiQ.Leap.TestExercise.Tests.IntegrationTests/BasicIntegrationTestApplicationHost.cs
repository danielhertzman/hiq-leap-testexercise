using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace HiQ.Leap.TestExercise.Tests.IntegrationTests;

internal class BasicIntegrationTestApplicationHost : WebApplicationFactory<Program>
{
    private readonly string _environment;

    internal HttpClient HttpClient;

    public BasicIntegrationTestApplicationHost(string environment = "IntegrationTests")
    {
        _environment = environment;
        HttpClient = CreateClient();
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment(_environment);

        // Add mock/test services to the builder here
        //builder.ConfigureServices(services =>
        //{
        //    services.AddSingleton<IPersonService, PersonServiceStub>();
        //});

        return base.CreateHost(builder);
    }
}