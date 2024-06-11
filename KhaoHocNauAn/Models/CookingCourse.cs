using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhoaHocNauAn.Models
{
    [Table("CookingCourse")]
    public class CookingCourse
    {
        [Key]
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? Images { get; set; }
        public int Price { get; set; }
        public bool? IsActive { get; set; }
        public int Status { get; set; }
        public int StudentCount { get; set; }
        public string? LearnTime { get; set; }
		public string? Levels { get; set; }
        public DateTime? Deadline { get; set; }
        public int MenuID { get; set; }
        public int CategoryID { get; set; }
        public int TeacherID { get; set; }
       

    }
}
