using System;
using System.Collections.Generic;
using NewsOrg.ViewModels;
using Xamarin.Forms;

namespace NewsOrg.Views
{
    public partial class ArtcleDetailPage : ContentPage
    {
        ArticleDetailPageViewModel viewModel;

        public ArtcleDetailPage(ArticleDetailPageViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ArtcleDetailPage()
        {
            InitializeComponent();
        }

        void SaveArticle_Clicked(object sender, EventArgs e)
        {

        }
    }
}
