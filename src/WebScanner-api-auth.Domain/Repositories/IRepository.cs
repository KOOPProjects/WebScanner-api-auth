using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WebScanner_api_auth.Domain.Models;

namespace WebScanner_api_auth.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : DatabaseEntity
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
