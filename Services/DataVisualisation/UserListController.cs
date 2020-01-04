using System;
using System.Linq;
using CrossRef.Common.Data;
using CrossRef.Services.DataVisualisation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrossRef.Services.DataVisualisation
{
	public class UserListController : Controller
	{
		[HttpGet]
		[Route("researchers")]
		public IActionResult UserList(bool wrongSearch = false)
		{
			var userListViewModel = new UserListViewModel { WrongSearch = wrongSearch };

			using (var db = new CrossRefContext())
			{
				var users = db.Users.Include("ArticleAuthors").Where(u => u.ArticleAuthors.Count > 0).ToList();

				var userList = users.Select(user => Tuple.Create(user.FirstName + " " + user.LastName, user.Id)).ToList();

				userListViewModel.Users = userList;
			}

			return View(userListViewModel);
		}
	}
}