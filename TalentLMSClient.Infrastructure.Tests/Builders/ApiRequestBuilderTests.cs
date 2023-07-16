using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TalentLMSClient.Domain.Entities.Common;
using TalentLMSClient.Infrastructure.Builders;

namespace TalentLMSClient.Infrastructure.Tests.Builders;

[ExcludeFromCodeCoverage]
[TestClass()]
public class ApiRequestBuilderTests
{

    [TestMethod()]
    public async Task GetHttpRequestMessage_Returns_RequstMessage()
    {
        // Arrange
        var apiRoute = "courses";
        var method = HttpMethod.Get;
        var settings = new TalentLMSApiSettings
        {
            BaseUrl = "https://example.com",
            ApiKey = "1234567890",
            ApiPath = "api",
            ApiVersion = "v1",
        };
        var baseUrl = settings.BaseUrl;
        var apiVersion = settings.ApiVersion;
        var apiPath = settings.ApiPath;
        var apiKey = settings.ApiKey;

        var apiUrl = new Uri($"{baseUrl}/{apiPath}/{apiVersion}/{apiRoute}");
        var base64ApiKey = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiKey));

        var expectedRequest = new HttpRequestMessage(method, $"{apiUrl}");
        expectedRequest.Headers.Add("Authorization", $"Basic {base64ApiKey}");

        // Act
        var actualRequest = new ApiRequestBuilder(settings, method, apiRoute).GetHttpRequestMessage();

        // Assert
        actualRequest.Should().BeEquivalentTo(expectedRequest);
    }
}