using FluentAssertions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics.CodeAnalysis;
using TalentLMSClient.Application.Courses;
using TalentLMSClient.Domain.Entities;
using TalentLMSClient.Domain.Entities.Common;
using TalentLMSClient.Infrastructure.Services;

namespace TalentLMSClient.Infrastructure.Tests.Services;

[ExcludeFromCodeCoverage]
[TestClass]
public class CouresesServiceTests
{
    private Mock<IOptions<TalentLMSApiSettings>> _configOptions;
    private Mock<ICourseService> _service;
    private Mock<HttpClient> _httpClient;

    [TestInitialize]
    public void Initialize()
    {
        _configOptions = new Mock<IOptions<TalentLMSApiSettings>>();
        _service = new Mock<ICourseService>();
        var test = _configOptions.Object.Value;
        _httpClient = new Mock<HttpClient>();
    }

    [TestMethod]
    public void CouresesServiceTest()
    {
        //Arrange
        _configOptions.Setup(x => x.Value).Returns(new TalentLMSApiSettings
        {
            ApiKey = "123",
            ApiPath = "https://test.com",
            ApiVersion = "v1",
            BaseUrl = "https://test.com"
        });

        //Act
        var service = new CoureseService(_configOptions.Object);

        //Assert
        Assert.IsNotNull(service);
    }

    [TestMethod]
    public void GetCourses_Returns_ListOfCourses()
    {
        // Arrange
        _configOptions.Setup(x => x.Value).Returns(new TalentLMSApiSettings
        {
            ApiKey = "123",
            ApiPath = "https://test.com",
            ApiVersion = "v1",
            BaseUrl = "https://test.com"
        });
        var expectedResult = new List<Course>
        {
            new Course
            {
                Name = "Test Course",
                Description = "Test Description",
                Code = "123",
                CategoryId = "123",
                CreatorId = "123",
                Price = "0",
                TimeLimit = "0"
            }};

        _service.Setup(s => s.GetCourses()).ReturnsAsync(expectedResult);
        
        // Act
        var actualResult = _service.Object.GetCourses().Result;


        // Assert
        _configOptions.Verify(x => x.Value, Times.Once);
        _service.Verify(x => x.GetCourses(), Times.Once);

        actualResult.Should().BeEquivalentTo(expectedResult);
    }
}