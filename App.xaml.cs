using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EmployeeAllowanceApp.Data;
using System.IO;

namespace EmployeeAllowanceApp
{
    public partial class App : Application
    {
        static AllowanceDatabase database;

            public static AllowanceDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AllowanceDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EmployeeAllowanceApp  .db3"));
                }
                return database;
            }
        }



        public App()
        {
            InitializeComponent();

              MainPage = new NavigationPage (new MainPage());
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Green;
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
