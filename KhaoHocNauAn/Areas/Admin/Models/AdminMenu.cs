using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhoaHocNauAn.Areas.Admin.Models
{
	[Table("AdminMenu")]
	public class AdminMenu
	{
		public int AdminMenuID { get; set; }
		public string? Name { get; set; }
		public bool IsActive { get; set; }
		public string? Icon { get; set; }
		public string? AreaName { get; set; }
		public string? ControllerName { get; set; }
		public string? ActionName { get; set; }

	}
}
