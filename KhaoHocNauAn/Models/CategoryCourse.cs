using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhoaHocNauAn.Models
{
    public class CategoryCourse
    {
        public required List<View_Detail_CookingCourse> DetailCourses { get; set; }
        public required List<Category> Categories { get; set; }
    }
}
