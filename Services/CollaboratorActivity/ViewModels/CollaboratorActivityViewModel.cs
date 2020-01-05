using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossRef.Services.CollaboratorActivity.ViewModels
{
    public class CollaboratorsPublicationViewModel
    {
        public string Title { get; set; }
        public DateTime? Published { get; set; }
        public string AuthorName { get; set; }
        public string Type { get; set; }
        public string AuthorsNames { get; set; }
        public string Url { get; set; }
    }

    public class CollaboratorActivityViewModel
    {
        public string searchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public List<CollaboratorsPublicationViewModel> Publications { get; set; }

        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;
        public string CurrentFilter { get; set; }
    }
}
