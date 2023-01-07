using EmployeeAllowanceApp.Model;
using EmployeeAllowanceApp.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace EmployeeAllowanceApp.View_Model
{
    public class AllowanceView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private AllowanceModel allowancemodel;






        public ObservableCollection<AllowanceModel> Items { get; set; }
        private AllowanceModel selectedAllowance;
        public List<AttendanceModel> AttendancesItem { get; set; }
        //public List<UserInfoModel> UiInfo { get; set; }

        private decimal allowanceAmount;
        public Command SaveCommand { get; }


        //This is for select Allowance
        public AllowanceModel SelectedAllowance
        {
            get
            {
                return selectedAllowance;
            }
            set
            {
                selectedAllowance = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AllowanceName"));
            }

        }

        //This is for Filling Amount
        public decimal AllowanceAmount
        {
            get
            {
                return allowanceAmount;
            }
            set
            {
                allowanceAmount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AllowanceAmount"));
            }

        }

        //This is for select Attendance 
        private bool isSelect;
        private object New_ListData;

        public bool IsSelected
        {
            get
            {
                return isSelect;
            }
            set
            {
                isSelect = value;
                NotifyPropertyChanged("IsSelected");
            }
        }

        public AllowanceView()
        {
            SaveCommand = new Command(onSave);
            Allowance allowanceservices = new Allowance();

            AttendancesItem = (List<AttendanceModel>)allowanceservices.GetAttendances();
            Items = (ObservableCollection<AllowanceModel>)allowanceservices.GetAllowances();
        }


        public async void onSave()
        {
            try
            {
                Allowance allowanceservices = new Allowance();
                int allowanceId = SelectedAllowance.AllowanceId;
                decimal ammount = AllowanceAmount;

                List<AllowanceModel> allowanceList = new List<AllowanceModel>();
                if (AllowanceAmount <= 0)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Amount Should Not be Empty", "Ok");

                }

                else
                {
                    foreach (var emp in AttendancesItem)
                    {
                        if (emp.IsSelected)
                        {
                            AllowanceModel allowancemodel = new AllowanceModel
                            {
                                Employeekey = emp.Employeekey,
                                AllowanceId = SelectedAllowance.AllowanceId,
                                AllowanceAmount = AllowanceAmount,
                                ClockDate = DateTime.Now,
                                isUpload = false
                            };
                          //  App.Database.SaveAllowanceAsync(allowancemodel);
                            allowanceList.Add(allowancemodel);
                        }
                        //var data = App.Database.SaveAllowanceAsync(allowanceList);
                        
                    }

                    SQLData newService = new SQLData();
                    App.Database.SaveAllowanceAsync(allowanceList);
                    newService.UploadData();


                    await App.Current.MainPage.DisplayAlert("Success", "AllowanceAmount is added Successfully", "Ok");
                    //App.Database.SaveAllowanceAsync(allowanceList);
                    
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
