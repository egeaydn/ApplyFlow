using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplyFlow.Enums;
using ApplyFlow.Identity;

namespace ApplyFlow.Models
{
	public class JobApplication
	{
		public int id { get; set; }

		[Required]
		[MaxLength(100)]
		public string CompanyName { get; set; } = null!;

		[Required]
		[MaxLength(100)]
		public string Position { get; set; } = null!;

		public DateTime AppliedDate { get; set; }

		public ApplicationStatus Status { get; set; }

		[MaxLength(1000)]
		public string? Notes { get; set; }

		public string? JobLink { get; set; }

		// 🔑 AUTH LINK
		[Required]
		public string UserId { get; set; } = null!;

		[ForeignKey(nameof(UserId))]
		public ApplicationUser User { get; set; } = null!;

		public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
