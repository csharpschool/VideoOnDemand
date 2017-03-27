using System.ComponentModel;

namespace VideoOnDemand.Models.DTOModels
{
    public class UserCourseDTO
    {
        [DisplayName("User Id")]
        public string UserId { get; set; }
        [DisplayName("Course Id")]
        public int CourseId { get; set; }
        [DisplayName("Email")]
        public string UserEmail { get; set; }
        [DisplayName("Title")]
        public string CourseTitle { get; set; }
    }
}
