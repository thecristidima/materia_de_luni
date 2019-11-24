using System;
using System.Diagnostics;
using System.Linq;
using CrossRef.Data;
using CrossRef.Models;
using CrossRef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrossRef.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}

		[HttpPost]
		public IActionResult Search(SearchViewModel model)
		{
			var individualNames = model.ResearcherName.Split(" ");

			if (individualNames.Length != 2)
			{
				return RedirectToAction("UserList", "UserList", false);
			}

			var firstName = individualNames[0];
			var lastName = individualNames[1];

			using (var db = new CrossRefContext())
			{
				var candidateUser = db.Users.FirstOrDefault(u =>
					u.FirstName.Equals(firstName, StringComparison.InvariantCultureIgnoreCase)
					&& u.LastName.Equals(lastName, StringComparison.InvariantCultureIgnoreCase)
					|| u.FirstName.Equals(lastName, StringComparison.InvariantCultureIgnoreCase)
					&& u.LastName.Equals(firstName, StringComparison.InvariantCultureIgnoreCase));

				if (candidateUser == null)
				{
					return RedirectToAction("UserList", "UserList", false);
				}

				return RedirectToAction("Overview", "Profile", new {id = candidateUser.Id});
			}
		}
	}
}