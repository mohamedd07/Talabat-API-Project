﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbContext;

        public GenericRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            //if(typeof(T) == typeof(Product))
            //    return (IEnumerable<T>) await _dbContext.Set<Product>().Include(p => p.Brand).Include(p=> p.Category).AsNoTracking().ToListAsync();
            
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }


        public async Task<T?> GetAsync(int id)
        {
            //if (typeof(T) == typeof(Product))
            //    return await _dbContext.Set<Product>().Where(p=> p.Id == id).Include(p=> p.Brand).Include(p=> p.Category).FirstOrDefaultAsync() as T;

            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).AsNoTracking().ToListAsync();
        }

        

        public async Task<T?> GetWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();

        }

        // Private Method That We Use Inside Class Only
        private IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
        {
            return SpecificationsEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }
    }
}
