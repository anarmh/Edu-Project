using Edu.Models;

namespace Edu.Service.Interface
{
    public interface ICourseService
    {
        public Task<IEnumerable<Course>> GetCoursesAsync();
    }
}
