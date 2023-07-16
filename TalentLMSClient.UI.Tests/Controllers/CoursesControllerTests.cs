using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics.CodeAnalysis;
using TalentLMSClient.Application.Courses.Queries;
using FluentAssertions;
using TalentLMSClient.Domain.Entities;

namespace TalentLMSClient.UI.Controllers.Tests;

[ExcludeFromCodeCoverage]
[TestClass()]
public class CoursesControllerTests
{
    private Mock<IMediator> _mediatorMock;
    private CoursesController _controller;

    [TestInitialize]
    public void TestInitialize()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new CoursesController(_mediatorMock.Object);
    }

    [TestMethod()]
    public async Task GetAsync_ReturnsViewResult()
    {
        // Arrange
        var request = new GetCoursesRequest();

        // TODO: Setup mock behavior Figure out how to mock the MediatR Send method
       // _mediatorMock.Setup(m => m.Send<IRequest>(It.IsAny<IRequest<IRequest>>(), CancellationToken.None)).Returns(new List<Course> { });

        // Act
        var result = await _controller.GetAsync(request);

        // Assert
        result.Should().NotBeNull()
              .And.BeOfType<ViewResult>();

        // Verify mock interactions
        //_mediatorMock.Verify(mock => mock.Send(request), Times.Once);
    }
}