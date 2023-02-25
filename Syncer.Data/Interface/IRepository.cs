using Microsoft.EntityFrameworkCore;
using Syncer.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Syncer.Data.Interface
{
    public interface IRepository
    {
        SMSContext GetSMSContext();
        DbSet<T> GetQuery<T>() where T : class;
        T GetEntity<T>(Expression<Func<T, bool>> whereCondition) where T : class;
        T GetEntity<T>(Expression<Func<T, bool>> whereCondition, string include) where T : class;
        void Add<T>(T entity) where T : class;
        T Create<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void SaveChanges();
    }
}
