namespace Edu.Models
{
    public class CourseImg
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public bool IsDeleted { get; set; }
        public string ImgUrl { get; set; }
    }
}
