using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplyFlow.Enums;
using ApplyFlow.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ApplyFlow.Models
{
	public class JobApplication
	{
		public int Id { get; set; }

		[Required, MaxLength(100)]
		public string CompanyName { get; set; } = null!;

		[Required, MaxLength(100)]
		public string Position { get; set; } = null!;

		public DateTime AppliedDate { get; set; } = DateTime.UtcNow;

		public ApplicationStatus Status { get; set; }
			= ApplicationStatus.Applied;

		[MaxLength(1000)]
		public string? Notes { get; set; }

		[MaxLength(500)]
		public string? JobLink { get; set; }

		// 👇 SERVER TARAFI
		[ValidateNever]
		public string ApplicationUserId { get; set; } = null!;

		[ValidateNever]
		public ApplicationUser User { get; set; } = null!;

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
