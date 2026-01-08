using ApplyFlow.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplyFlow.Controllers
{
	[Authorize]
	public class JobApplicationsController : Controller
	{
		private readonly AppDbContext _dbContext;
		private readonly UserManager<ApplicationUser> _applicationUser;

		public JobApplicationsController(
			AppDbContext dbContext,
			UserManager<ApplicationUser> applicationUser
		)

		{
			
		}
		public async Task <IActionResult> Index()
		{
			var userId = _applicationUser.GetUserId(User);

			var applications = await _dbContext.JobApplications
				.Where(x => x.ApplicationUserId == userId)
				.OrderByDescending(x => x.AppliedDate)
				.ToListAsync();

			return View(applications);
		}
	}
}
