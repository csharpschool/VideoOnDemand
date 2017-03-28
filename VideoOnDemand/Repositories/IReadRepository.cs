using System.Collections.Generic;
using VideoOnDemand.Entities;

namespace VideoOnDemand.Repositories
{
    interface IReadRepository
    {
        IEnumerable<Course> GetCourses(string userId);
        Course GetCourse(string userId, int courseId);
    }
}
