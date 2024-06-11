using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KhoaHocNauAn.Models
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public string? TeacherName { get; set; }
        public string? Gender { get; set; }
        public string? Description { get; set; }
        public string? Degree { get; set; }
        public int Phone { get; set; }
        public string? Email { get; set;}
		public string? Position { get; set; }
		public bool? IsActive { get; set; }
        public int Status { get; set; }
        public string? TeachImages { get; set; }

    }
}
