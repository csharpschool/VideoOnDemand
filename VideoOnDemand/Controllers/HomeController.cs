using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using VideoOnDemand.Models;
using VideoOnDemand.Repositories;

namespace VideoOnDemand.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;

        public HomeController(SignInManager<ApplicationUser> signInMgr)
        {
            _signInManager = signInMgr;
        }

        public IActionResult Index()
        {
            var rep = new MockReadRepository();
            var courses = rep.GetCourses("4ad684f8-bb70-4968-85f8-458aa7dc19a3");
            var course = rep.GetCourse("4ad684f8-bb70-4968-85f8-458aa7dc19a3", 1);
            var video = rep.GetVideo("4ad684f8-bb70-4968-85f8-458aa7dc19a3", 1);
            var videos = rep.GetVideos("4ad684f8-bb70-4968-85f8-458aa7dc19a3");
            var videosForModule = rep.GetVideos("4ad684f8-bb70-4968-85f8-458aa7dc19a3", 1);

            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction("Login", "Account");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
