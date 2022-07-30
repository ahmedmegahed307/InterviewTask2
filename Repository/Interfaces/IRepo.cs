using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace AFS_.NET_Developer_Test.Repository.Interfaces
{
    
    public interface IRepo <T> where T : class
    {
        // I added all these methods Incase we need to use another translator, and I used some of it.
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
