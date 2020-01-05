using CrossRef.Common.Data;
using CrossRef.Common.Data.Entities;
using CrossRef.Services.ArticleAdd.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CrossRef.Services.ArticleAdd
{
    [Authorize]
    public class ArticleAddController: Controller
    {

        [HttpGet("AddArticle")]
        public async Task<IActionResult> AddArticle()
        {
            using (var _context = new CrossRefContext())
            {
                var dbUsers = await _context
                .Users
                .Where(x => x.Id != GetUserId())
                .OrderBy(x => x.FirstName)
                .ToListAsync();

                ArticleViewModel articleViewModel = new ArticleViewModel()
                {
                    Users = dbUsers.Select(x => new SelectListItem
                    {
                        Text = $"{x.FirstName} {x.LastName}",
                        Value = x.Id.ToString()
                    }).ToList()
                };

                return View(articleViewModel);
            }
            
        }

        [HttpPost("AddArticle")]
        public async Task<IActionResult> AddArticlePost(ArticleViewModel articleViewModel)
        {
            using (var _context = new CrossRefContext())
            {
                Article newPublication = new Article()
                {
                    Title = articleViewModel.Title,
                    Published = articleViewModel.PublishedTime,
                    YearOfPublication = articleViewModel.PublishedTime.Year
                };
                List<ArticleAuthors> articleAuthors = new List<ArticleAuthors>();
                articleAuthors.Add(new ArticleAuthors()
                {
                    UserId = GetUserId(),
                    Article = newPublication
                });
                _context.Articles.Add(newPublication);

                List<Collaborator> collaborators = new List<Collaborator>();
                foreach (int id in articleViewModel.SelectedUserIds)
                {
                    articleAuthors.Add(new ArticleAuthors()
                    {
                        UserId = id,
                        Article = newPublication
                    });
                    Collaborator collaborator = new Collaborator()
                    {
                        AuthorId = GetUserId(),
                        CollaboratorId = id
                    };
                    collaborators.Add(collaborator);
                }
                _context.Collaborators.AddRange(collaborators);
                _context.ArticleAuthors.AddRange(articleAuthors);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction("Index", "Home");
        }

        private int GetUserId()
        {
            using (var _context = new CrossRefContext())
            {
                User user = _context.Users.First(u => u.Email.Equals(User.FindFirst(ClaimTypes.Email).Value));
                return user == null ? -1 : user.Id;
            }
        }
    }
}
