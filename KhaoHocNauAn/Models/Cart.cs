using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhoaHocNauAn.Models
{
	[Table("Cart")]
	public class Cart
	{
		[Key]
		public int CourseID { get; set; }
		public string? CourseName { get; set; }
		public string? Images { get; set; }
		public int Price { get; set; }
		public DateTime? Deadline { get; set; }

	}
}
