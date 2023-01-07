using EmployeeAllowanceApp.Model;
using EmployeeAllowanceApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


using Xamarin.Forms.Xaml;


namespace EmployeeAllowanceApp
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class MainPage : ContentPage
    {
        public object Title { get;}


        public MainPage()
        {
            InitializeComponent();
            Title = "Allowance Login-App";

        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            Allowance service = new Allowance();
            var getLoginDetails =  service.GetUiInfo(entryUserName.Text, entryPassword.Text);
            if (getLoginDetails)
            {


              //  var a = App.Database.GetAllowancAsync();
                await Navigation.PushAsync(new AllowancePage());
            }
            else
            {
                await DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }

            //if (entryUserName.Text == "a" && entryPassword.Text == "a")
            //{
            //    DisplayAlert("Login Successful!", "Welcome ", "OK");
            //    Navigation.PushAsync(new AllowancePage());
            //}


            //else if (entryUserName.Text == null && entryPassword.Text == null)
            //{
            //    DisplayAlert("Alert!", "Entry should not be Empty", "OK");

            //}
            //else
            //{
            //    DisplayAlert("Alert!", "Invalid Password or Username" , "OK");
            //}
        }
    }
}

           

        //{
        //    //if (Application.Current.Properties.ContainsKey("Username")
        //    //    && Application.Current.Properties.ContainsKey("Password")) ;
        //}
        //{
        //    var username = Application.Current.Properties["Username"] as string;
        //    var password = Application.Current.Properties["Password"] as string;
        //    var firstname = Application.Current.Properties["Firstname"] as string;

        //    if (entryUserName.Text == username && entryPassword.Text == password)
        //    {
        //        DisplayAlert("Login Successful!", "Welcome " + firstname + "!", "OK");
        //    }

        //    else
        //    {
        //        DisplayAlert("", "Login Failed!", "OK");
        //    }
        //}

        //    else
        //    {
        //        DisplayAlert("", "Login Failed!", "OK");
        //    }
        //}

        //private void btnRegister_Clicked(object sender, EventArgs e)
        //{

        //}

    





