using System;
using NewsOrg.Models;

namespace NewsOrg.ViewModels
{
    //
    public class ArticleDetailPageViewModel : BaseViewModel
    {
        public Article Article { get; set; }
        public ArticleDetailPageViewModel(Article article = null)
        {
            Title = article?.Title;
            Article = article;
        }
    }
}
