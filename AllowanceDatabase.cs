using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using EmployeeAllowanceApp.Model;
using System;

namespace EmployeeAllowanceApp.Data
{
    public class AllowanceDatabase
    {
        readonly SQLiteAsyncConnection database;

        public AllowanceDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<AllowanceModel>().Wait();
        }

        public Task<List<AllowanceModel>> GetAllowancAsync()
        {
            // Get a specific note.
            return database.Table<AllowanceModel>().ToListAsync();
        }



        public async Task<bool> SaveAllowanceAsync(List<AllowanceModel> allowanceModel)
        {
                       // Save a new note.
            await database.InsertAllAsync(allowanceModel);
            return true;
        }


       public async Task<bool> UpdateAllowanceAsync(List<AllowanceModel> DetailEmp)
        {
            try
            {
                foreach(var i in DetailEmp)
                {
                    i.isUpload = true;
                    await database.UpdateAsync(i);
                }
                return true;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }



        public async Task<bool> DeleteAllowanceAsync(List<AllowanceModel> isdeleteallowance)
            {
                try
                {
                    foreach (var i in isdeleteallowance)
                    {
                        await database.DeleteAsync(i);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }



            }
        }
    }
