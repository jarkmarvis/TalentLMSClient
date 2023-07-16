using MediatR;
using TalentLMSClient.Domain.Entities;

namespace TalentLMSClient.Application.Courses.Queries;

/// <summary>
/// Request to get all courses.
/// </summary>
public class GetCoursesRequest : IRequest<IEnumerable<Course>>
{ }
