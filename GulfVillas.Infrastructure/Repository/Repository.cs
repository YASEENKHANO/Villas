using GulfVillas.Application.Common.Interfaces;
using GulfVillas.Domain.Entites;
using GulfVillas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GulfVillas.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet; // this is a property of type DbSet<T> that will hold the set of entities of type T
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet= _db.Set<T>();// this means we are getting the set of entities of type T from the database context
        }
        
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {


            IQueryable<T> query = dbSet;//this means 
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //for Villa,VillaNumber and it will be case sensitive
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {

            IQueryable<T> query = dbSet;//this means 
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //for Villa,VillaNumber and it will be case sensitive
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
