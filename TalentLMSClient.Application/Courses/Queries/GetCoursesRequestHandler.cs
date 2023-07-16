using MediatR;
using TalentLMSClient.Domain.Entities;

namespace TalentLMSClient.Application.Courses.Queries;

/// <summary>
/// Implements the request handler for the <see cref="GetCoursesRequest"/> request.
/// </summary>
public class GetCoursesRequestHandler : IRequestHandler<GetCoursesRequest, IEnumerable<Course>>
{
    private readonly ICourseService _courseService;
    

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="courseService">The injected course service</param>
    public GetCoursesRequestHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    /// <summary>
    ///  Get all courses.
    /// </summary>
    /// <param name="request">GetCourseRequest</param>
    /// <param name="cancellationToken">The cancelation token</param>
    /// <returns>IEnumerable of Courses</returns>
    /// <exception cref="Exception"></exception>
    async Task<IEnumerable<Course>> IRequestHandler<GetCoursesRequest, IEnumerable<Course>>.Handle(GetCoursesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _courseService.GetCourses();
            return await ValueTask.FromResult(result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
