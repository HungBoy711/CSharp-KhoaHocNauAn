using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace KhoaHocNauAn.Models
{
	[Table("InvoiceDetail")]
	public class InvoiceDetail
	{
		[Key]
		public int InvoiceDetailID { get; set; }
		public int InvoiceID { get; set; }
		public int CourseID { get; set; }
		public string? CourseName { get; set; }
		public string? Images { get; set; }
		public int Price { get; set; }
		public virtual Invoice InvoiceIDNavigation { get; set; } = null!;
	}
}
