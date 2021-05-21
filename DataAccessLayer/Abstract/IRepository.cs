using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> List();
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
