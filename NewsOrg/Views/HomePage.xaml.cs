using System;
using System.Collections.Generic;
using NewsOrg.ViewModels;
using Xamarin.Forms;
using NewsOrg.Models;

namespace NewsOrg.Views
{
    public partial class HomePage : ContentPage
    {
        HomePageViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new HomePageViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var article = args.SelectedItem as Article;
            if (article == null)
                return;

            await Navigation.PushAsync(new ArtcleDetailPage(new ArticleDetailPageViewModel(article)));

            //Manually deselect item.
            ArtclesListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Articles.Count == 0)
                viewModel.LoadArticlesCommand.Execute(null);
        }
    }

}

