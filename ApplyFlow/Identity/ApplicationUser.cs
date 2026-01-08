using ApplyFlow.Enums;
using ApplyFlow.Models;
using Microsoft.AspNetCore.Identity;
namespace ApplyFlow.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? ProfilePhotoUrl { get; set; }
		public UserType UserType { get; set; } = UserType.Applicant;
		public DateTime CreateAt { get; set; } = DateTime.UtcNow;
		public ICollection<JobApplication> JobApplications { get; set; } 
			= new List<JobApplication>();
	}
}
