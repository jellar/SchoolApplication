using AutoMapper;
using SchoolApplication.Data;
using SchoolApplication.Service;
using SchoolApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService courseService;

        public HomeController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        public ActionResult Index()
        {
            var courseViewModel = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courseService.GetCourses());
            return View(courseViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}