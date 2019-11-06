using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using NewsOrg.Models;
using NewsOrg.Services;
using Xamarin.Forms;
using Xamarin.Essentials;
using Realms;
using System.Linq;

namespace NewsOrg.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        RemoteService remoteService = new RemoteService();
        public ObservableCollection<Article> Articles { get; set; }
        public Command LoadArticlesCommand { get; set; }
        public HomePageViewModel()
        {

            Title = "Home";
            Articles = new ObservableCollection<Article>();
            LoadArticlesCommand = new Command(async () => await ExecuteLoadArticlesCommand());
        }

        async Task ExecuteLoadArticlesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    // Connection to internet is available
                    Articles.Clear();

                    //Mak call to remote api
                    var articles = await remoteService.AllNewsResponseAsync();
                    if(articles.Articles != null)
                    {
                        foreach (var article in articles.Articles)
                        {
                            Articles.Add(article);
                            await App.Database.SaveArticleAsync(article);
                        }
                    }
                }

                //if unavailablity of internet get articles from database
                else
                {
                    var articles = await App.Database.GetArticlesAsync();
                    foreach (var article in articles)
                    {
                        Articles.Add(article);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
