using Edu.Models;

namespace Edu.Areas.Admin.ViewModels.Courses
{
    public class CourseDetailVM
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public List<CourseImg> CourseImgs { get; set; }
    }
}
