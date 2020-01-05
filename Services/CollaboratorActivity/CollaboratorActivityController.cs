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

        public async Task OnGetAsync(CollaboratorActivityViewModel collaboratorActivityViewModel)
        {
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

                    List<Article> publications = await _context.Articles
                        .Where(x => x.ArticleAuthors.Select(y => y.UserId).Intersect(collaboratorsIds).Any()
                            && x.ArticleAuthors.Select(y => y.UserId).Intersect(searchedUsersIds).Any())
                        .OrderByDescending(x => x.Published)
                        .Skip((collaboratorActivityViewModel.CurrentPage - 1) * collaboratorActivityViewModel.PageSize)
                        .Take(collaboratorActivityViewModel.PageSize)
                        .ToListAsync();

                    List<CollaboratorsPublicationViewModel> collaboratorsPublications = new List<CollaboratorsPublicationViewModel>();
                    foreach (Article publication in publications)
                    {
                        string authorsNames = String.Join(String.Empty, publication.ArticleAuthors.Select(x => x.User.FirstName + " " + x.User.LastName));
                        CollaboratorsPublicationViewModel pub = new CollaboratorsPublicationViewModel()
                        {
                            Title = publication.Title,
                            Published = publication.Published,
                            //AuthorName = users.FirstOrDefault(x => x.Id == publication.AuthorId)?.UserName,
                            AuthorsNames = authorsNames,
                            Url = publication.Url,
                            Type = publication.Type
                        };
                        collaboratorsPublications.Add(pub);
                    }

                    //Publications = collaboratorsPublications;
                    //Count = _context.Publications.Where(x => collaboratorsIds.Contains(x.AuthorId) && searchedUsersIds.Contains(x.AuthorId)).Count();
                }
            }
            else
            {
                //Publications = new List<CollaboratorsPublicationViewModel>();
                //Count = 0;
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
