using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using HiQ.Leap.TestExercise.Domain.Models;
using HiQ.Leap.TestExercise.Domain.RequestModels;
using HiQ.Leap.TestExercise.Services.Contracts;
using HiQ.Leap.TestExercise.Tests.IntegrationTests.Stubs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HiQ.Leap.TestExercise.Tests.IntegrationTests;

public class PersonControllerTests
{
    private static readonly JsonSerializerOptions CaseInsensitivityOption = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Fact]
    public async Task Get_Persons_Return_Empty_List_Success_StatusCode()
    {
        // Arrange
        await using var application = new BasicIntegrationTestApplicationHost();
        var httpClient = application.HttpClient;

        // Act
        var httpResponse = await httpClient.GetAsync("/Persons");

        var responseBodyString = await httpResponse.Content.ReadAsStringAsync();
        var personList = JsonSerializer.Deserialize<List<Person>>(responseBodyString, CaseInsensitivityOption);

        // Assert
        httpResponse.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.Empty(personList);
    }

    [Fact]
    public async Task Post_Person_Return_Expected_Values_Created_StatusCode()
    {
        // Arrange - Override implementation of IPersonService to a stub defined in Stubs folder
        var applicationHost = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IPersonService, PersonServiceStub>();
            });
        });

        var httpClient = applicationHost.CreateClient();

        // Act
        var request = new PersonCreateRequest()
        {
            // Person numbers can be generated from fejk.se
            PersonNumber = "6406090826",
            GivenName = "",
            SurName = ""
        };
        var httpResponse = await httpClient.PostAsJsonAsync("/Persons", request);
        var responseBodyString = await httpResponse.Content.ReadAsStringAsync();
        var person = JsonSerializer.Deserialize<Person>(responseBodyString, CaseInsensitivityOption);

        // Assert
        httpResponse.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.Created, httpResponse.StatusCode);
        Assert.NotNull(person);

        // Asserting the values set in the stub class
        Assert.Equal("FakePersonNumber", person.PersonNumber);
        Assert.Equal("Stub", person.GivenName);
        Assert.Equal("Fake", person.SurName);
    }
}