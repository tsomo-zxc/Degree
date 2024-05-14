//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using Degree.MVVM.Models;
//using SQLite;

//namespace Degree.Repositories
//{
//    public class CustomerRepository
//    {
//        SQLiteConnection connection;
//        public string StatusMessage { get; set; }

//        public CustomerRepository()
//        {
//            StatusMessage = "";
//            connection = new SQLiteConnection(Constants.DbPath, Constants.DbFlags);
//            connection.CreateTable<Customer>();

//        }

//        public void AddOrUpdate(Customer customer)
//        {
//            int res = 0;

//            try
//            {
//                if (customer.ID != 0)
//                {
//                    res = connection.Update(customer);
//                    StatusMessage = $"{res} row(s) updated";
//                }
//                else
//                {
//                    res = connection.Insert(customer);
//                    StatusMessage = $"{res} row(s) added";
//                }

//            }
//            catch (Exception ex)
//            {
//                StatusMessage = $"Error : {ex.Message}";
//            }
//        }

//        public void Delete(int customerId)
//        {
//            try
//            {
//                var customer = Get(customerId);
//                connection.Delete(customer);
//            }
//            catch (Exception ex)
//            {
//                StatusMessage = $"Error : {ex.Message}";
//            }
//        }

//        public List<Customer> GetAll()
//        {
//            try
//            {
//                return connection.Table<Customer>().ToList();
//            }
//            catch (Exception ex)
//            {
//                StatusMessage = $"Error : {ex.Message}";
//            }
//            return null;
//        }

//        public List<Customer> GetAll(Expression<Func<Customer,bool>> predicate)
//        {
//            try
//            {
//                return connection.Table<Customer>().Where(predicate).ToList();
//            }
//            catch (Exception ex)
//            {
//                StatusMessage = $"Error : {ex.Message}";
//            }
//            return null;
//        }

//        public List<Customer> GetAll2()
//        {
//            try
//            {
//                return connection.Query<Customer>("SELECT * FROM Customers").ToList();
//            }
//            catch (Exception ex)
//            {
//                StatusMessage = $"Error : {ex.Message}";
//            }
//            return null;
//        }

//        public Customer Get(int id)
//        {
//            try
//            {
//                return
//                    connection.Table<Customer>()
//                    .FirstOrDefault(x => x.ID == id);
//            }
//            catch (Exception ex)
//            {
//                StatusMessage = $"Error : {ex.Message}";
//            }
//            return null;
//        }


//    }
//}
