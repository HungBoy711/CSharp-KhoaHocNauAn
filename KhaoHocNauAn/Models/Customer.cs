using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhoaHocNauAn.Models
{
	[Table("Customer")]
	public class Customer
	{
		[Key]
		public int CustomerID { get; set; }
		public string? CustomerName { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set;}
		public int Phone { get; set; }
		public bool? IsActive { get; set; }
	}
}
