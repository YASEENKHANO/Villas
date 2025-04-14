using GulfVillas.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GulfVillas.Application.Common.Interfaces
{
    //if we do not know which class will implement this we make a generic class
    public interface IRepository<T> where T : class
    {
        //we have Villa with T as we do not know which class will use this repository
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);

        void Add(T entity);

        bool Any(Expression<Func<T, bool>> filter);
        void Remove(T entity);

      //update can be different for every class

    }
}
