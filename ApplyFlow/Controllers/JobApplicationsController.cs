using ApplyFlow.Identity;
using ApplyFlow.Models;
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
			_dbContext = dbContext;
			_applicationUser = applicationUser;
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
		[Authorize]
		public IActionResult Create()
		{
			return View();
		}
		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Create(JobApplication model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			model.ApplicationUserId = _applicationUser.GetUserId(User)!;
			model.CreatedAt = DateTime.UtcNow;

			var errors = ModelState
			   .SelectMany(x => x.Value.Errors)
			   .Select(x => x.ErrorMessage)
			   .ToList();

			foreach (var error in errors)
				Console.WriteLine(error);

			_dbContext.JobApplications.Add(model);
			await _dbContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
	}
}
