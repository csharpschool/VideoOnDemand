using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using VideoOnDemand.Models;
using AutoMapper;
using VideoOnDemand.Repositories;

namespace VideoOnDemand.Controllers
{
    public class MembershipController : Controller
    {
        private string _userId;
        private IReadRepository _db;
        private readonly IMapper _mapper;
        public MembershipController(IHttpContextAccessor httpContextAccessor, 
            UserManager<ApplicationUser> userManager, IMapper mapper, IReadRepository db)
        {
            // Get Logged in user's UserId
            var user = httpContextAccessor.HttpContext.User;
            _userId = userManager.GetUserId(user);
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Course()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Video()
        {
            return View();
        }
    }
}