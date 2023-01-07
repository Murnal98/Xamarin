using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EmployeeAllowanceApp.Model;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Newtonsoft;
using Newtonsoft.Json;

namespace EmployeeAllowanceApp.Service
{
    public class Allowance
    {
        private List<AttendanceModel> AttendancesItem { get; set; }
        private ObservableCollection<AllowanceModel> Items { get; set; }

        
        

        private string MainWebServiceUrl= "http://172.23.48.1/PMAPI/api/EmployeeAllowanceDetails/";
        public IEnumerable<AllowanceModel> GetAllowances()
        {
            var uri = new Uri(MainWebServiceUrl + "Allowance");
            var client = new HttpClient();
            var response = client.GetStringAsync(uri);
            Items = JsonConvert.DeserializeObject<ObservableCollection<AllowanceModel>>(response.Result);
            return Items;
        }

        public IEnumerable<AttendanceModel> GetAttendances()
        {
            var uri = new Uri(MainWebServiceUrl + "todayEmpAttendance");

            var client = new HttpClient();
            var response = client.GetStringAsync(uri);
            AttendancesItem = JsonConvert.DeserializeObject<List<AttendanceModel>>(response.Result);
            return AttendancesItem;
        }

        public List<AllowanceModel> AllowanceList { get; set; }
        public bool PostAllowance(List<AllowanceModel> AllowanceList)
        {
            
            string Josn = JsonConvert.SerializeObject(AllowanceList);
            HttpContent httpContent = new StringContent(Josn, Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var Client = new HttpClient();
            var responce = Client.PostAsync(MainWebServiceUrl + "postAllowance", httpContent);
            return responce.Result.IsSuccessStatusCode;

            
        }

        public object PostAllowance()
        {
            throw new NotImplementedException();
        }

        public bool GetUiInfo(string UserName, string Password)
        {
           
            HttpClient client = new HttpClient();
            var response =  client.GetStringAsync("http://172.23.48.1/PMAPI/api/EmployeeAllowanceDetails/User?UserName=" + UserName + "&Password=" + Password);
            if (response.Result.Contains(UserName) && response.Result.Contains(Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}


