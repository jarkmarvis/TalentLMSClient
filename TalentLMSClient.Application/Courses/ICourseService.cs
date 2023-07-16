using TalentLMSClient.Domain.Entities;

namespace TalentLMSClient.Application.Courses;

/// <summary>
/// Abstraction for the course service.
/// </summary>
public interface ICourseService
{
    /// <summary>
    /// Get all courses.
    /// </summary>
    /// <returns></returns>
    Task<List<Course>> GetCourses();
}
