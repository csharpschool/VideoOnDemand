using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VideoOnDemand.Data;
using VideoOnDemand.Entities;
using VideoOnDemand.Models;
using VideoOnDemand.Models.DTOModels;

namespace VideoOnDemand.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("admin/[controller]/[action]")]
    public class UserCoursesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserStore<ApplicationUser, IdentityRole, ApplicationDbContext> _userStore;

        public UserCoursesController(UserStore<ApplicationUser, IdentityRole, ApplicationDbContext> userStore)
        {
            _db = userStore.Context;
            _userStore = userStore;
        }

        public IActionResult Index()
        {
            var model = _db.Courses
                .Join(_db.UserCourses, c => c.Id, uc => uc.CourseId, (c, uc) => new { Courses = c, UserCourses = uc })
                .Select(s => new UserCourseDTO { CourseId = s.Courses.Id, CourseTitle = s.Courses.Title, UserId = s.UserCourses.UserId, UserEmail = _userStore.Users.FirstOrDefault(u => u.Id.Equals(s.UserCourses.UserId)).Email });

            return View(model);
        }

        public async Task<IActionResult> Details(string userId, int courseId)
        {
            if (userId == null || courseId.Equals(default(int)))
            {
                return NotFound();
            }

            var model = await _db.Courses
                .Join(_db.UserCourses, c => c.Id, uc => uc.CourseId, (c, uc) => new { Courses = c, UserCourses = uc })
                .Select(s => new UserCourseDTO { CourseId = s.Courses.Id, CourseTitle = s.Courses.Title, UserId = s.UserCourses.UserId, UserEmail = _userStore.Users.FirstOrDefault(u => u.Id.Equals(s.UserCourses.UserId)).Email })
                .FirstOrDefaultAsync(w => w.CourseId.Equals(courseId) && w.UserId.Equals(userId));

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_db.Courses, "Id", "Title");
            ViewData["UserId"] = new SelectList(_userStore.Users, "Id", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,CourseId")] UserCourse userCourse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Add(userCourse);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "That combination already exist.");
                }
            }
            ViewData["CourseId"] = new SelectList(_db.Courses, "Id", "Title", userCourse.CourseId);
            ViewData["UserId"] = new SelectList(_userStore.Users, "Id", "Email");
            return View();
        }

        public async Task<IActionResult> Edit(string userId, int courseId)
        {
            if (userId == null || courseId.Equals(default(int)))
            {
                return NotFound();
            }

            var model = await _db.UserCourses.SingleOrDefaultAsync(m => m.UserId.Equals(userId) && m.CourseId.Equals(courseId));

            if (model == null)
            {
                return NotFound();
            }

            ViewData["CourseId"] = new SelectList(_db.Courses, "Id", "Title");
            ViewData["UserId"] = new SelectList(_userStore.Users, "Id", "Email");
            return View(model);
        }

        private bool UserCourseExists(string userId, int courseId)
        {
            return _db.UserCourses.Any(e => e.UserId.Equals(userId) && e.CourseId.Equals(courseId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string originalUserId, int originalCourseId, [Bind("UserId,CourseId")] UserCourse userCourse)
        {
            if (originalUserId == null || originalCourseId.Equals(default(int)))
            {
                return NotFound();
            }

            var orignalUserCourse = await _db.UserCourses
                .SingleOrDefaultAsync(c => c.UserId.Equals(originalUserId) && c.CourseId.Equals(originalCourseId));

            if (!UserCourseExists(userCourse.UserId, userCourse.CourseId))
            {
                try
                {
                    _db.Remove(orignalUserCourse);
                    _db.Add(userCourse);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch
                {
                }
            }

            ModelState.AddModelError("", "Unable to save changes.");
            ViewData["CourseId"] = new SelectList(_db.Courses, "Id", "Title", userCourse.CourseId);
            ViewData["UserId"] = new SelectList(_userStore.Users, "Id", "Email");

            return View(userCourse);
        }

        public async Task<IActionResult> Delete(string userId, int courseId)
        {
            if (userId == null || courseId.Equals(default(int)))
            {
                return NotFound();
            }

            var model = await _db.Courses
                .Join(_db.UserCourses, c => c.Id, uc => uc.CourseId, (c, uc) => new { Courses = c, UserCourses = uc })
                .Select(s => new UserCourseDTO { CourseId = s.Courses.Id, CourseTitle = s.Courses.Title, UserId = s.UserCourses.UserId, UserEmail = _userStore.Users.FirstOrDefault(u => u.Id.Equals(s.UserCourses.UserId)).Email })
                .FirstOrDefaultAsync(w => w.CourseId.Equals(courseId) && w.UserId.Equals(userId));

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string userId, int courseId)
        {
            var userCourse = await _db.UserCourses.SingleOrDefaultAsync(m => m.UserId.Equals(userId) && m.CourseId.Equals(courseId));
            _db.UserCourses.Remove(userCourse);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #region Alternate Edit Action
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string originalUserId, int originalCourseId)
        //{
        //    if (originalUserId == null && originalCourseId < 1)
        //    {
        //        return NotFound();
        //    }

        //    var studentToUpdate = await _db.UserCourses.SingleOrDefaultAsync(s => s.UserId == originalUserId && s.CourseId == originalCourseId);
        //    if (await TryUpdateModelAsync<UserCourse>(
        //        studentToUpdate,
        //        "",
        //        s => s.UserId, s => s.CourseId))
        //    {
        //        try
        //        {
        //            await _db.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }
        //        catch (DbUpdateException)
        //        {
        //            ModelState.AddModelError("", "Unable to save changes.");
        //        }
        //    }
        //    return View(studentToUpdate);
        //}
        #endregion
    }
}
