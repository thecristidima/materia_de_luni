using System.Linq;
using System.Security.Claims;
using CrossRef.Common.Data;
using CrossRef.Services.DataVisualisation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrossRef.Services.Permissions
{
    public class PermissionsController : Controller
    {
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

                return RedirectToAction("MyOverview", "Profile");
            }
        }
    }
}