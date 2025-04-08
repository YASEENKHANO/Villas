﻿using GulfVillas.Application.Common.Interfaces;
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
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Villa entity)
        {
            _db.Add(entity);
        }

        public Villa Get(Expression<Func<Villa, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Villa> query = _db.Set<Villa>();//this means 
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

        public IEnumerable<Villa> GetAll(Expression<Func<Villa, bool>>? filter = null, string? includeProperties = null)
        {//explain the above code: 
            IQueryable<Villa> query = _db.Set<Villa>();//this means 
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

        public void Remove(Villa entity)
        {
            _db.Remove(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Villa entity)
        {
           _db.Villas.Update(entity);
        }
    }
}
