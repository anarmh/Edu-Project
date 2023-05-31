using Edu.DAL;
using Edu.Models;
using Edu.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Edu.Service
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _context.Courses.Include(m => m.CourseImgs).Where(m => !m.IsDeleted).Take(3).ToListAsync();
        }
    }
}
