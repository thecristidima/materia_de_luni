using System;
using System.Collections.Generic;
using System.Linq;
using CrossRef.Data;
using CrossRef.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrossRef.Controllers
{
	public class UserListController : Controller
	{
		[HttpGet]
		[Route("researchers")]
		public IActionResult UserList(bool wrongSearch = false)
		{
			var userListViewModel = new UserListViewModel();
			userListViewModel.WrongSearch = wrongSearch;

			using (var db = new CrossRefContext())
			{
				var users = db.Users.Include("ArticleAuthors").Where(u => u.ArticleAuthors.Count > 0).ToList();

				var userList = new List<Tuple<string, int>>();

				foreach (var user in users)
				{
					userList.Add(Tuple.Create(user.FirstName + " " + user.LastName, user.Id));
				}

				userListViewModel.Users = userList;
			}

			return View(userListViewModel);
		}
	}
}