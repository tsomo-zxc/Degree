using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Degree.MVVM.Abstractions
{
    public interface IBaseRepository<T> : IDisposable
        where T : TableData, new()
    {
        void SaveItem(T item);
        void SaveItemWithChildren(T item, bool recursive = false);
        void DeleteItem(T item);
        T GetItem(int id);
        T GetItem(Expression<Func<T, bool>> expression);
        List<T> GetItems();
        List<T> GetItems(Expression<Func<T, bool>> expression);
        List<T> GetItemsWithChildren(Expression<Func<T, bool>> expression);
        List<T> GetItemsWithChildren();
        
    }
}
