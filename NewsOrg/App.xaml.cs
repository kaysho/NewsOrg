using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NewsOrg.Services;
using NewsOrg.Views;
using NewsOrg.Database;
using System.IO;

namespace NewsOrg
{
    public partial class App : Application
    {
        public static string BackendUrl = "https://newsapi.org/v2/";

        //static varialble to access database
        static NewsOrgDatabase database;

        public static NewsOrgDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NewsOrgDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
