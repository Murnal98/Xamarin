using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using EmployeeAllowanceApp.Model;

namespace EmployeeAllowanceApp.Service
{
    public class SQLData
    {

        public SQLData()
        {
            Device.StartTimer(TimeSpan.FromSeconds(20 ), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                UploadData()
                );
                return true;
            });
        }
        public void UploadData()
        {
            try
            {
                List<AllowanceModel> data = App.Database.GetAllowancAsync().Result;
                if (data.Count > 0)
                {
                    var Allowanceservies = new Allowance();
                    var response = Allowanceservies.PostAllowance(data);
                    if (response == true)
                    {
                        App.Database.DeleteAllowanceAsync(data);
                        //App.Database.UpdateAllowanceAsync(data);

                    }
                }
               // App.Database.DeleteAllowanceAsync(data);
            }


            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    }
}
