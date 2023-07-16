using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentLMSClient.Application.Courses.Queries;

namespace TalentLMSClient.UI.Controllers;

public class CoursesController : Controller
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get all courses.
    /// </summary>
    /// <returns></returns>
    /// TODO Add Exceptions
    [Route("courses")]
    [HttpGet]
    public async Task<IActionResult> GetAsync(GetCoursesRequest request)
    {
        await _mediator.Send(request);
        return View();
    }
}
