using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossRef.Services.ArticleAdd.ViewModels
{
    public class ArticleViewModel
    {
        public string Title { get; set; }
        public DateTime PublishedTime { get; set; }
        public int[] SelectedUserIds { get; set; }
        public List<SelectListItem> Users { get; set; }
    }
}
