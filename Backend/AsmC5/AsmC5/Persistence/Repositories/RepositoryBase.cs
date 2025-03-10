﻿using AsmC5.Context;
using AsmC5.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AsmC5.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        protected RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        //AsNoTracking (ON) : True
        //AsNoTracking (OFF) : False

        public async Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false)
        {
            return !asNoTracking
                ? await _dbSet.ToListAsync()
                : await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id, bool asNoTracking = false)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            }
            return await _dbSet.FindAsync(id);
        }
        public async Task<T?> GetUserByIdAsync(string id, bool asNoTracking = false)
        {
            if (asNoTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<string>(e, "Id") == id);
            }
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> FindAll(bool asNoTracking = false) =>
            asNoTracking ?
            _context.Set<T>().AsNoTracking() :
            _context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool asNoTracking = false) =>
            asNoTracking ?
            _context.Set<T>().Where(expression).AsNoTracking() :
            _context.Set<T>().Where(expression);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            return !asNoTracking
                ? await _dbSet.Where(predicate).ToListAsync()
                : await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);

        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetOrCreateAsync(
            Expression<Func<T, bool>> predicate,
            Func<T> createNew)
        {
            var entity = await _context.Set<T>()
                                      .FirstOrDefaultAsync(predicate);

            if (entity == null)
            {
                entity = createNew();
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

    }
}
