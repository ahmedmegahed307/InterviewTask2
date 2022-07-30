using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AFS_.NET_Developer_Test.InfraStructure;
using AFS_.NET_Developer_Test.Models;
using AFS_.NET_Developer_Test.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AFS_.NET_Developer_Test.Repository.BusinessClasses
{
    public class RepoService<T> : IRepo<T> where T : class 
    {
        // I added all these methods Incase we need to use another translator, and I used some of it.
        private readonly ProjectContext _context;
        public RepoService(ProjectContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            var addedEntity = _context.Set<T>().Add(entity);
                _context.SaveChanges();
        }


        public void Update(T entity)
        {
            var updatedEntity = _context.Set<T>().Update(entity);
            _context.SaveChanges();

        }


        public void Delete(T entity)
        {
            var deleteedEntity = _context.Set<T>().Remove(entity);
                _context.SaveChanges();
        }


        public T Get(Expression<Func<T, bool>> filter)
        {
           
                return _context.Set<T>().FirstOrDefault(filter);
            
        }



        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {

            return filter == null
                ? _context.Set<T>()
                : _context.Set<T>().Where(filter);
        }

       
    }
}
