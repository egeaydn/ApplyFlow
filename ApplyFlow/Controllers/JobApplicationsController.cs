using ApplyFlow.Identity;
using ApplyFlow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

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

		public async Task<IActionResult> Index()
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
		public async Task<IActionResult> Details(int id)
		{
			var application = await _dbContext.JobApplications
				.Include(x => x.User)
				.FirstOrDefaultAsync(x => x.Id == id);

			if (application == null)
			{
				return NotFound();
			}

			if (application.ApplicationUserId != _applicationUser.GetUserId(User))
				return Forbid();

			return View(application);
		}

		public async Task<IActionResult> Edit(int id)
		{

			var application = await _dbContext.JobApplications.FindAsync(id);

			if (application == null)
			{
				return NotFound();
			}

			if (application.ApplicationUserId != _applicationUser.GetUserId(User))
				return Forbid();

			return View(application);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, JobApplication model)
		{
			if (id != model.Id)
			{
				return BadRequest();
			}
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var existing = await _dbContext.JobApplications.FindAsync(id);

			if (existing == null)
			{
				return NotFound();
			}

			if (existing.ApplicationUserId != _applicationUser.GetUserId(User))
				return Forbid();

			existing.CompanyName = model.CompanyName;
			existing.Position = model.Position;
			existing.AppliedDate = model.AppliedDate;
			existing.Status = model.Status;
			existing.Notes = model.Notes;
			existing.JobLink = model.JobLink;

			await _dbContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			var application = await _dbContext.JobApplications.FindAsync(id);

			if (application == null)
				return NotFound();

			_dbContext.JobApplications.Remove(application);
			await _dbContext.SaveChangesAsync();

			if (application.ApplicationUserId != _applicationUser.GetUserId(User))
				return Forbid();
	
			return RedirectToAction(nameof(Index));
		}

	}
}
