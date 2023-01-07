using EmployeeAllowanceApp.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeAllowanceApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllowancePage : ContentPage
    {
        public AllowancePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
            BindingContext = new View_Model.AllowanceView();
            

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.mylabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
                return true; 
            });
        }

        
        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Amount());

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.DarkGreen;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }
    }
}