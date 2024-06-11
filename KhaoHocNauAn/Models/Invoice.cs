using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhoaHocNauAn.Models
{
	[Table("Invoice")]
	public class Invoice 
	{
		public int InvoiceID { get; set; }
		public int CustomerID { get; set; }
		public string? CustomerName { get; set; }
		public int Phone { get; set; }
		public string? Email { get; set; }
		public string? Description { get; set; }
		public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
		
	}
}
