using System.Linq;
using System.Security.Claims;
using CrossRef.Common.Data;
using CrossRef.Services.DataVisualisation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrossRef.Services.DataVisualisation
{
	[Authorize]
	[Route("profile")]
	public class ProfileController : Controller
	{
		[HttpGet("overview")]
		public IActionResult MyOverview()
		{
			return View("Overview");
		}

		[AllowAnonymous]
		[HttpGet("overview/{id}")]
		public IActionResult Overview(int id)
		{
			using (var db = new CrossRefContext())
			{
				if (!db.Users.Any(u => u.Id == id))
				{
					return NotFound();
				}

				if (User.Identity.IsAuthenticated
				    && User.FindFirst(ClaimTypes.Email).Value.Equals(db.Users.First(u => u.Id == id).Email))
				{
					return View();
				}

				var profileViewModel = GenerateProfileViewModelForUser(id);

				return View(profileViewModel);
			}
		}

		[HttpGet("settings")]
		public IActionResult Settings()
		{
			using (var db = new CrossRefContext())
			{
				var user = db.Users.First(u => u.Email.Equals(
					User.FindFirst(ClaimTypes.Email).Value));

				var settingsViewModel = new SettingsViewModel
				{
					FirstName = user.FirstName,
					LastName = user.LastName,
					Biography = user.Biography,
					DateOfBirth = user.DateOfBirth,
					Affiliation = user.Affiliation
				};

				return View(settingsViewModel);
			}
		}

		[HttpPost("settings")]
		public IActionResult Settings(SettingsViewModel settingsViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(settingsViewModel);
			}

			using (var db = new CrossRefContext())
			{
				var user = db.Users.First(u => u.Email.Equals(
					User.FindFirst(ClaimTypes.Email).Value));

				user.FirstName = settingsViewModel.FirstName;
				user.LastName = settingsViewModel.LastName;
				user.Affiliation = settingsViewModel.Affiliation;
				user.Biography = settingsViewModel.Biography;
				user.DateOfBirth = settingsViewModel.DateOfBirth;

				db.Update(user);
				db.SaveChanges();

				return View("Overview");
			}
		}

		[HttpGet("articles")]
		public IActionResult Articles()
		{
			using (var db = new CrossRefContext())
			{
				var articleViewModel = new ArticlesViewModel();

				var articles = db.Users
					.Where(u => u.Email.Equals(
						User.FindFirst(ClaimTypes.Email).Value))
					.SelectMany(u => u.ArticleAuthors)
					.Select(a => a.Article)
					.ToList();

				articleViewModel.Articles = articles;

				return View(articleViewModel);
			}
		}

		private static ProfileViewModel GenerateProfileViewModelForUser(int id)
		{
			using (var db = new CrossRefContext())
			{
				var user = db.Users.Include(u => u.Permission).First(u => u.Id == id);
				var permission = user.Permission;

				var profileViewModel = new ProfileViewModel
				{
					FirstName = user.FirstName,
					LastName = user.LastName,
					ShowArticles = permission.ShowArticles,
					ShowBiography = permission.ShowBiography,
					ShowAffiliation = permission.ShowAffiliation,
					ShowDateOfBirth = permission.ShowDateOfBirth
				};

				if (profileViewModel.ShowArticles)
				{
					profileViewModel.Articles = db.Users.Where(u => u.Id == id).SelectMany(u => u.ArticleAuthors)
						.Select(aa => aa.Article).ToList();
				}

				if (profileViewModel.ShowAffiliation)
				{
					profileViewModel.Affiliation = user.Affiliation;
				}

				if (profileViewModel.ShowBiography)
				{
					profileViewModel.Biography = user.Biography;
				}

				if (profileViewModel.ShowDateOfBirth)
				{
					profileViewModel.DateOfBirth = user.DateOfBirth;
				}

				return profileViewModel;
			}
		}
	}
}