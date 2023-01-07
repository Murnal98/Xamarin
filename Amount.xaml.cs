using DocumentFormat.OpenXml.Office2010.Word;
using EmployeeAllowanceApp.Model;
using EmployeeAllowanceApp.View_Model;
using Syncfusion.XForms.Buttons;
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
    public partial class Amount : ContentPage
    {
        private AllowanceView vm;
        private int Checked;
        private object collectionView;

        public Amount()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = vm = new AllowanceView();
        }


        private void CheckBox_CheckChange(object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            try
            {
                int total = vm.AttendancesItem.Count();
                int select = vm.AttendancesItem.Where(emp => emp.IsSelected).Count();
                Checked = total = select;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    // Retrieve all the notes from the database, and set them as the
        //    // data source for the CollectionView.
        //    List.ItemsSource = await App.Database.GetNotesAsync();
        //}

        //async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.CurrentSelection != null)
        //    {
        //        // Navigate to the NoteEntryPage, passing the ID as a query parameter.
        //        AllowanceModel note = (AllowanceModel)e.CurrentSelection.FirstOrDefault();
        //        await Shell.Current.GoToAsync($"{nameof(Amount)}?{nameof(Amount.ItemId)}={allowanceModel.Employeekey.ToString()}");
        //    }
        //}


       //async void LoadNote(int Employeekey)
       // {
       //     try
       //     {
       //         int Empkey = Convert.ToInt32(Employeekey);
       //         // Retrieve the note and set it as the BindingContext of the page.
       //         AllowanceModel allowanceModel = await App.Database.GetAllowancAsync(Empkey);
       //         BindingContext = allowanceModel;
       //     }
       //     catch (Exception)
       //     {
       //         Console.WriteLine("Failed to load note.");
       //     }
       // }

      

      
    }
}
