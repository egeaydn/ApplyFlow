using ApplyFlow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplyFlow.Identity
{
	public class AppDbContext : IdentityDbContext<ApplicationUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext>options) : base (options)
		{
		}
		public DbSet<JobApplication> JobApplications { get; set; }
	}
}
