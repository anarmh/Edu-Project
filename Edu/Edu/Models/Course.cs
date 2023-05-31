namespace Edu.Models
{
    public class Course
    {
        public int Id { get; set; }
        public decimal  Price { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public bool IsDeleted { get; set; }
        public List<CourseImg> CourseImgs { get; set; }
    }
}
