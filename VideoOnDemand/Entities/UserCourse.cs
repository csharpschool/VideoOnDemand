using System.ComponentModel.DataAnnotations;

namespace VideoOnDemand.Entities
{
    public class UserCourse
    {
        [Display(Name = "User")]
        public string UserId { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
