using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CrossRef.Common.Data;
using CrossRef.Common.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrossRef.Services.ArticleFetch
{
    public class ArticleFetchController : Controller
    {
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
    }
}
