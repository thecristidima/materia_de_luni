using CrossRef.Common.Data;
using CrossRef.Common.Data.Entities;
using CrossRef.Services.CollaboratorActivity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CrossRef.Services.CollaboratorActivity
{
    [Authorize]
    public class CollaboratorActivityController : Controller
    {

        [HttpGet("CollaboratorActivity")]
        public async Task<IActionResult> CollaboratorActivity(CollaboratorActivityViewModel collaboratorActivityViewModel)
        {
            if (collaboratorActivityViewModel.searchString == null) collaboratorActivityViewModel.searchString = "";
            collaboratorActivityViewModel.CurrentFilter = collaboratorActivityViewModel.searchString;

            List<int> collaboratorsIds = GetCollaboratorsIds();
            if (collaboratorsIds != null && collaboratorsIds.Count > 0)
            {
                using (var _context = new CrossRefContext())
                {
                    List<User> users = GetUsers();
                    List<int> searchedUsersIds = users
                        .Where(x => collaboratorActivityViewModel.searchString == null
                        || (x.FirstName + " " + x.LastName).ToUpper().Contains(collaboratorActivityViewModel.searchString.ToUpper()))
                        .Select(x => x.Id)
                        .ToList();

                    List<Article> publications = await _context.Articles.Include(x => x.ArticleAuthors).ThenInclude(x => x.User)
                        .Where(x => x.ArticleAuthors.Select(y => y.UserId).Intersect(collaboratorsIds).Any()
                            && x.ArticleAuthors.Select(y => y.UserId).Intersect(searchedUsersIds).Any())
                        .OrderByDescending(x => x.Published)
                        .Skip((collaboratorActivityViewModel.CurrentPage - 1) * collaboratorActivityViewModel.PageSize)
                        .Take(collaboratorActivityViewModel.PageSize)
                        .ToListAsync();

                    List<CollaboratorsPublicationViewModel> collaboratorsPublications = new List<CollaboratorsPublicationViewModel>();
                    foreach (Article publication in publications)
                    {
                        string authorsNames = "";
                        var authors = publication?.ArticleAuthors?.Select(x => x.User.FirstName + " " + x.User.LastName + " ");
                        if (authors != null)
                        {
                            authorsNames = String.Join(String.Empty, authors);
                        }
                        var author = users
                            .FirstOrDefault(x => publication.ArticleAuthors.Select(y => y.UserId).Contains(x.Id) &&
                            (x.FirstName + " " + x.LastName).ToUpper().Contains(collaboratorActivityViewModel.searchString.ToUpper()));
                        string authorName = author?.FirstName + " " + author.LastName;
                        CollaboratorsPublicationViewModel pub = new CollaboratorsPublicationViewModel()
                        {
                            Title = publication.Title,
                            Published = publication.Published,
                            AuthorName = authorName,
                            AuthorsNames = authorsNames,
                            Url = publication.Url,
                            Type = publication.Type,
                            Year = publication.YearOfPublication
                        };
                        collaboratorsPublications.Add(pub);
                    }

                    CollaboratorActivityViewModel collaboratorViewModel = new CollaboratorActivityViewModel()
                    {
                        Publications = collaboratorsPublications,
                        Count = collaboratorsPublications.Count()
                    };
                    return View(collaboratorViewModel);
                }
            }
            else
            {
                CollaboratorActivityViewModel collaboratorViewModel = new CollaboratorActivityViewModel()
                {
                    Publications = new List<CollaboratorsPublicationViewModel>(),
                    Count = 0
                };
                return View(collaboratorViewModel);
            }
        }

        private List<int> GetCollaboratorsIds()
        {
            using (var _context = new CrossRefContext())
            {
                return _context.Collaborators.Where(x => x.AuthorId == GetUserId()).Select(x => x.CollaboratorId).ToList();
            }
        }

        private int GetUserId()
        {
            using (var _context = new CrossRefContext())
            {
                User user = _context.Users.First(u => u.Email.Equals(User.FindFirst(ClaimTypes.Email).Value));
                return user == null ? -1 : user.Id;
            }
        }

        private List<User> GetUsers()
        {
            using (var _context = new CrossRefContext())
            {
                return _context.Users.Where(x => x.Id != GetUserId()).ToList();
            }
        }
    }
}
