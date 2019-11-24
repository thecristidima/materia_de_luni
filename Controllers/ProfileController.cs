using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CrossRef.Data;
using CrossRef.Data.Entities;
using CrossRef.Models.ViewModels;
using CrossRef.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrossRef.Controllers
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

				var profileViewModel = generateProfileViewModelForUser(id);

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

		[HttpGet("permissions")]
		public IActionResult Permissions()
		{
			using (var db = new CrossRefContext())
			{
				var user = db.Users.Include("Permission").First(u =>
					u.Email.Equals(
						User.FindFirst(ClaimTypes.Email).Value
					));

				var permissionsViewModel = new PermissionsViewModel
				{
					ShowBiography = user.Permission.ShowBiography,
					ShowAffiliation = user.Permission.ShowAffiliation,
					ShowArticles = user.Permission.ShowArticles,
					ShowDateOfBirth = user.Permission.ShowDateOfBirth
				};

				return View(permissionsViewModel);
			}
		}

		[HttpPost("permissions")]
		public IActionResult Permissions(PermissionsViewModel permissionsViewModel)
		{
			using (var db = new CrossRefContext())
			{
				var user = db.Users.Include("Permission").First(u =>
					u.Email.Equals(
						User.FindFirst(ClaimTypes.Email).Value
					));

				user.Permission.ShowAffiliation = permissionsViewModel.ShowAffiliation;
				user.Permission.ShowArticles = permissionsViewModel.ShowArticles;
				user.Permission.ShowBiography = permissionsViewModel.ShowBiography;
				user.Permission.ShowDateOfBirth = permissionsViewModel.ShowDateOfBirth;

				db.Update(user);
				db.SaveChanges();

				return RedirectToAction("MyOverview");
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

		[HttpPost("articles")]
		public async Task<IActionResult> FetchArticles()
		{
			using (var db = new CrossRefContext())
			{
				var user = db.Users.First(u => u.Email.Equals(
					User.FindFirst(ClaimTypes.Email).Value));

				var articles = await CrossRefService.FetchArticles(
					user.FirstName + " " + user.LastName,
					user.Affiliation);

				foreach (var article in articles)
				{
					var existingArticle = db.Articles
						.Include("ArticleAuthors")
						.FirstOrDefault(a => a.DOI.Equals(article.DOI));

					if (existingArticle != null)
					{
						if (existingArticle.ArticleAuthors.Any(aa => aa.UserId == user.Id))
						{
							continue;
						}

						var manyToManyBullshit = existingArticle.ArticleAuthors;
						manyToManyBullshit.Add(new ArticleAuthors
						{
							User = user,
							Article = existingArticle
						});

						existingArticle.ArticleAuthors = manyToManyBullshit;
						db.Articles.Update(existingArticle);
						db.SaveChanges();
					}
					else
					{
						var newArticle = new Article
						{
							DOI = article.DOI,
							Title = article.Title,
							YearOfPublication = article.YearOfPublication
						};

						var aa = new ArticleAuthors
						{
							Article = newArticle,
							User = user
						};
						newArticle.ArticleAuthors = new List<ArticleAuthors> {aa};

						db.Articles.Add(newArticle);
						db.SaveChanges();
					}
				}
			}

			return RedirectToAction("MyOverview", "Profile");
		}

		private ProfileViewModel generateProfileViewModelForUser(int id)
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