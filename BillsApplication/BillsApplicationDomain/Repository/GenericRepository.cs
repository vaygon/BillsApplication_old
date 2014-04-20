using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BillsApplicationDomain.Repository
{
    public interface IGenericRepository
    {
        void Create<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
        T GetById<T>(int id) where T : class;
        void Update<T>(T entity) where T : class;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> match) where T : class;
        IQueryable<T> FindAll<T>() where T : class;
    }
    
    
    public class GenericRepository :IGenericRepository
    {
        private DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Create<T>(T entity) where T: class
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(int id) where T : class 
        {
            _context.Entry(GetById<T>(id)).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public T GetById<T>(int id) where T : class 
        {
            return _context.Set<T>().Find(id);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> match) where T : class
        {
            return _context.Set<T>().Where(match);   
        }

        public IQueryable<T> FindAll<T>() where T : class
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}