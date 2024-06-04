using Degree.MVVM.Abstractions;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Degree.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public BaseRepository()
        {
            StatusMessage = "";
            connection = new SQLiteConnection(Constants.DbPath, Constants.DbFlags);
            Console.WriteLine(Constants.DbPath);
            connection.CreateTable<T>();
        }
        public void DeleteItem(T item)
        {
            try
            {               
                connection.Delete(item);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error : {ex.Message}";
            }
        }

        public void Dispose()
        {
            connection.Close();
        }

        public T GetItem(int id)
        {
            try
            {
                return
                    connection.Table<T>()
                    .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error : {ex.Message}";
            }
            return null;
        }

        public T GetItem(Expression<Func<T, bool>> expression)
        {
            try
            {
                return connection.Table<T>().Where(expression).FirstOrDefault();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error : {ex.Message}";
            }
            return null;
        }

        public List<T> GetItems()
        {
            try
            {
                return connection.Table<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error : {ex.Message}";
            }
            return null;
        }

        public List<T> GetItems(Expression<Func<T, bool>> expression)
        {
            try
            {
                return connection.Table<T>().Where(expression).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error : {ex.Message}";
            }
            return null;
        }

        public void SaveItem(T item)
        {
            int res = 0;

            try
            {
                if (item.Id != 0)
                {
                    res = connection.Update(item);
                    StatusMessage = $"{res} row(s) updated";
                }
                else
                {
                    res = connection.Insert(item);
                    StatusMessage = $"{res} row(s) added";
                }

            }
            catch (Exception ex)
            {
                StatusMessage = $"Error : {ex.Message}";
            }
        }

        public void SaveItemWithChildren(T item, bool recursive = false) {
            connection.InsertWithChildren(item, recursive);
        }
        public void UpdateItemWithChildren(T item)
        {
            connection.UpdateWithChildren(item);
        }
        public List<T> GetItemsWithChildren()
        {
            try
            {
                return connection.GetAllWithChildren<T>().ToList();
            }
            catch (Exception ex )
            {

                StatusMessage = $"Error : {ex.Message}";
            }
            return null;
        }
        public List<T> GetItemsWithChildren(Expression<Func<T, bool>> expression)
        {
            try
            {
                return connection.GetAllWithChildren<T>(expression).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error : {ex.Message}";
            }
            return null;
        }


    }
}
