using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhoaHocNauAn.Models
{
	[Table("View_Registration")]
	public class View_Registration
	{
        [Key]
        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? Images { get; set; }
        public int Price { get; set; }
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public int Phone { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }

    }
}
