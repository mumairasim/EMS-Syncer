using Microsoft.EntityFrameworkCore;
using Syncer.Data.DatabaseContext;
using Syncer.Data.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Syncer.Data.Implementation
{
    public class Repository : IRepository
    {
        public readonly SMSContext _smsContext;

        public Repository(SMSContext smsContext)
        {
            _smsContext = smsContext;
        }

        public SMSContext GetSMSContext()
        {
            return _smsContext;
        }

        /// <summary>
        /// Use this to run queries
        /// The "[" "]" is for base types that are also reserved keywords.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public DbSet<T> GetQuery<T>() where T : class
        {
            return _smsContext.Set<T>();
        }

        /// <summary>
        /// Load a single item based on a condition
        /// Throws an InvalidOperationException if more than one object is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereCondition"></param>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <returns></returns>
        public T GetEntity<T>(Expression<Func<T, bool>> whereCondition) where T : class
        {
            return GetQuery<T>().Where(whereCondition).FirstOrDefault();
        }

        /// <summary>
        /// Load a single item based on a condition
        /// Throws an InvalidOperationException if more than one object is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereCondition"></param>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <returns></returns>
        public T GetEntity<T>(Expression<Func<T, bool>> whereCondition, string include) where T : class
        {
            return GetQuery<T>().Include(include).Where(whereCondition).FirstOrDefault();
        }


        /// <summary>
        /// Add an Entity to the ObjectContext
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Add<T>(T entity) where T : class
        {
            _smsContext.Set<T>().Add(entity);
            _smsContext.SaveChanges();
        }
        /// <summary>
        /// Add an Entity to the ObjectContext with return type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public T Create<T>(T entity) where T : class
        {
            var val = _smsContext.Set<T>().Add(entity).Entity;
            _smsContext.SaveChanges();
            return val;
        }

        /// <summary>
        /// Update an Object in the object context.
        /// Note that this does save the context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Update<T>(T entity) where T : class
        {
            _smsContext.Set<T>().Attach(entity);
            _smsContext.Entry(entity).State = EntityState.Modified;
            _smsContext.SaveChanges();
        }
        public void SaveChanges()
        {
            _smsContext.SaveChanges();
        }
    }
}
