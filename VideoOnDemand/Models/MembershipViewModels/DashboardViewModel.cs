using System.Collections.Generic;
using VideoOnDemand.Models.DTOModels;

namespace VideoOnDemand.Models.MembershipViewModels
{
    public class DashboardViewModel
    {
        public List<List<CourseDTO>> Courses { get; set; }
    }
}
