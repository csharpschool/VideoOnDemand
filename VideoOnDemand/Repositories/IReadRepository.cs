using System.Collections.Generic;
using VideoOnDemand.Entities;

namespace VideoOnDemand.Repositories
{
    interface IReadRepository
    {
        IEnumerable<Course> GetCourses(string userId);
    }
}
