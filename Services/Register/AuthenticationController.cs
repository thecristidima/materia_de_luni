using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CrossRef.Common.Data;
using CrossRef.Common.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;

namespace CrossRef.Services.Register
{
	public class AuthenticationController : Controller
	{
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			using (var db = new CrossRefContext())
			{
				if (db.Users.Any(u => u.Email.Equals(model.Email)))
				{
					ModelState.AddModelError("EmailAlreadyInUse", "Email address is already in use");
				}

				var user = new User
				{
					Email = model.Email,
					Password = EncryptPassword(model.Password),
					FirstName = model.FirstName,
					LastName = model.LastName
				};

				var permission = new Permission
				{
					Author = user,
					ShowArticles = false,
					ShowBiography = false,
					ShowAffiliation = false,
					ShowDateOfBirth = false
				};

				db.Users.Add(user);
				db.Permissions.Add(permission);
				db.SaveChanges();

				return RedirectToAction("Login", "Authentication");
			}
		}

		private static string EncryptPassword(string password)
		{
			return Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password,
				Encoding.ASCII.GetBytes("salt"),
				KeyDerivationPrf.HMACSHA1,
				10000,
				256 / 8));
		}

		[HttpGet]
		public IActionResult Login(string returnUrl)
		{
			return View(new LoginViewModel
			{
				ReturnUrl = returnUrl
			});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			if (!AreCredentialsValid(model.Email, model.Password))
			{
				ModelState.AddModelError("InvalidCredentials", "Invalid credentials");
				return View(model);
			}

			await LoginAsync(model.Email);

			if (!string.IsNullOrEmpty(model.ReturnUrl))
			{
				return Redirect(model.ReturnUrl);
			}

			return RedirectToAction("Index", "Home");
		}

		private async Task LoginAsync(string email)
		{
			using (var db = new CrossRefContext())
			{
				var user = db.Users.First(u => u.Email.Equals(email));

				var claims = new[]
				{
					new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
					new Claim(ClaimTypes.Email, user.Email)
				};

				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var principal = new ClaimsPrincipal(identity);
				await HttpContext.SignInAsync(principal);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Logout(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;

			return await Logout();
		}

		private static bool AreCredentialsValid(string email, string password)
		{
			using (var db = new CrossRefContext())
			{
				if (!db.Users.Any(u => u.Email.Equals(email)))
				{
					return false;
				}

				var user = db.Users.First(u => u.Email.Equals(email));

				return user.Password == Convert.ToBase64String(KeyDerivation.Pbkdf2(
					       password,
					       Encoding.ASCII.GetBytes("salt"),
					       KeyDerivationPrf.HMACSHA1,
					       10000,
					       256 / 8));
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			if (User.Identity.IsAuthenticated)
			{
				await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			}

			return RedirectToAction("Index", "Home");
		}
	}
}