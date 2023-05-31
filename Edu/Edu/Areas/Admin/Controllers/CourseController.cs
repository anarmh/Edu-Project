using Edu.Areas.Admin.ViewModels.Courses;
using Edu.DAL;
using Edu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Edu.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<CourseVM> list = new();

            List<Course> courses=await _context.Courses.Include(m=>m.CourseImgs).Where(m=>!m.IsDeleted).ToListAsync();

            foreach (var course in courses)
            {
                CourseVM model = new()
                {
                    Id = course.Id,
                    Description= course.Description,
                    Capacity= course.Capacity,
                    CourseImgs=course.CourseImgs,
                    Price= course.Price,
                };
                list.Add(model);
            }
            return View(list);
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();
            Course course = await _context.Courses.Include(m => m.CourseImgs).Where(m => !m.IsDeleted).FirstOrDefaultAsync(m => m.Id == id);

            if (course == null) return NotFound();
            CourseDetailVM model = new()
            {
                Price = course.Price,
                CourseImgs = course.CourseImgs,
                Description = course.Description,
                Capacity = course.Capacity,
            };
            return View(model);
        }
    }
}
