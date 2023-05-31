using Edu.DAL;
using Edu.Models;
using Edu.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edu.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly AppDbContext _context;
        public CourseController( ICourseService courseService,AppDbContext context)
        {
            _courseService= courseService;
            _context= context;
        }
            
        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> courses=await _courseService.GetCoursesAsync();
            var count= await _context.Courses.CountAsync();
            ViewBag.Count=count;
            return View(courses);
        }

        public async Task<IActionResult> LoadMore(int skip,int take)
        {

            IEnumerable<Course> courses=await _context.Courses.Skip(skip).Take(take).ToListAsync();

            return PartialView("_ProductPartial",courses);
        }
    }
}
