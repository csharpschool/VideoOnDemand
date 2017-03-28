using System.Collections.Generic;
using VideoOnDemand.Entities;

namespace VideoOnDemand.Repositories
{
    public class MockReadRepository : IReadRepository
    {
        #region Mock Data
        List<Course> _courses = new List<Course> {
            new Course{ Id = 1, InstructorId = 1, MarqueeImageUrl = "/images/laptop.jpg", ImageUrl = "/images/course.jpg", Title = "C# For Beginners", Description = "Course 1 Description: Some description that is very very long and longer still" },
            new Course{ Id = 2, InstructorId = 1, MarqueeImageUrl = "/images/laptop.jpg", ImageUrl = "/images/course2.jpg", Title = "Programming C#", Description = "Course 2 Description: Some description that is very very long and longer still" },
            new Course{ Id = 3, InstructorId = 2, MarqueeImageUrl = "/images/laptop.jpg", ImageUrl = "/images/course3.jpg", Title = "MVC 5 For Beginners", Description = "Course 3 Description: Some description that is very very long and longer still" }
        };

        List<UserCourse> _userCourses = new List<UserCourse>
        {
            new UserCourse { UserId = "4ad684f8-bb70-4968-85f8-458aa7dc19a3" , CourseId = 1 },
            new UserCourse { UserId = "00000000-0000-0000-0000-000000000000" , CourseId = 2 },
            new UserCourse { UserId = "4ad684f8-bb70-4968-85f8-458aa7dc19a3" , CourseId = 3 },
            new UserCourse { UserId = "00000000-0000-0000-0000-000000000000" , CourseId = 1 }
        };

        List<Module> _modules = new List<Module>
        {
            new Module { Id = 1, Title = "Module 1", CourseId = 1 },
            new Module { Id = 2, Title = "Module 2", CourseId = 1 },
            new Module { Id = 3, Title = "Module 3", CourseId = 2 }
        };

        List<Video> _videos = new List<Video>
        {
            new Video { Id = 1, ModuleId = 1, CourseId = 1, Position = 1, Title = "Video 1 Title", Description = "Video 1 Description: Some description that is very very long and longer still", Duration = 50, Thumbnail = "/images/video1.jpg", Url = "//csharpschooldemo.streaming.mediaservices.windows.net/8362603e-c01d-4628-86e3-19cb207bf96d/002 - Open the Azure Portal.ism/manifest" },
            new Video { Id = 2, ModuleId = 1, CourseId = 1, Position = 2, Title = "Video 2 Title", Description = "Video 2 Description: Some description that is very very long and longer still", Duration = 45, Thumbnail = "/images/video2.jpg", Url = "//csharpschooldemo.streaming.mediaservices.windows.net/8362603e-c01d-4628-86e3-19cb207bf96d/002 - Open the Azure Portal.ism/manifest" },
            new Video { Id = 3, ModuleId = 3, CourseId = 2, Position = 1, Title = "Video 3 Title", Description = "Video 3 Description: Some description that is very very long and longer still", Duration = 41, Thumbnail = "/images/video3.jpg", Url = "//csharpschooldemo.streaming.mediaservices.windows.net/8362603e-c01d-4628-86e3-19cb207bf96d/002 - Open the Azure Portal.ism/manifest" },
            new Video { Id = 4, ModuleId = 2, CourseId = 1, Position = 1, Title = "Video 4 Title", Description = "Video 4 Description: Some description that is very very long and longer still", Duration = 42, Thumbnail = "/images/video4.jpg", Url = "//csharpschooldemo.streaming.mediaservices.windows.net/8362603e-c01d-4628-86e3-19cb207bf96d/002 - Open the Azure Portal.ism/manifest" }
        };

        List<Instructor> _instructors = new List<Instructor>
        {
            new Instructor{
                Id = 1,
                Name = "John Doe",
                Thumbnail = "/images/Ice-Age-Scrat-icon.png",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            },
            new Instructor{
                Id = 2,
                Name = "Jane Doe",
                Thumbnail = "/images/Ice-Age-Scrat-icon.png",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            }
        };

        List<Download> _downloads = new List<Download>
        {
            new Download{Id = 1, ModuleId = 1, CourseId = 1, Title = "ADO.NET 1 (PDF)", Url = "https://1drv.ms/b/s!AuD5OaH0ExAwn48rX9TZZ3kAOX6Peg" },
            new Download{Id = 2, ModuleId = 1, CourseId = 1, Title = "ADO.NET 2 (PDF)", Url = "https://1drv.ms/b/s!AuD5OaH0ExAwn48rX9TZZ3kAOX6Peg" },
            new Download{Id = 3, ModuleId = 3, CourseId = 2, Title = "ADO.NET 1 (PDF)", Url = "https://1drv.ms/b/s!AuD5OaH0ExAwn48rX9TZZ3kAOX6Peg" }
        };

        #endregion
    }
}
