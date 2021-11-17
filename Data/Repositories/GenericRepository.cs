using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;



namespace StoreApp.Data.Repositories
{
    public class GenericRepository<StoreAppContext> : IRepository<StoreAppContext> where StoreAppContext : class
    {
        DbSet<StoreAppContext> _dbSet;
        private readonly DatabaseModel.StoreAppContext _DBEntity;

        public GenericRepository(DatabaseModel.StoreAppContext DBEntity)
        {
            _DBEntity = DBEntity;
            _dbSet = _DBEntity.Set<StoreAppContext>();
        }

        public void Add(StoreAppContext entity)
        {
            _dbSet.Add(entity);
            _DBEntity.SaveChanges();
        }

        public int GetAllContentCount()
        {
            return _dbSet.Count();
        }

        public IEnumerable<StoreAppContext> GetAllContents()
        {
            return _dbSet.ToList();
        }

        public IQueryable<StoreAppContext> GetAllContentsIQueryable()
        {
            return _dbSet;
        }

        public StoreAppContext GetFirstOrDefault(int contentId)
        {
            return _dbSet.Find(contentId);
        }

        public StoreAppContext GetFirstOrDefaultByParam(Expression<Func<StoreAppContext, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).FirstOrDefault();
        }

        public IEnumerable<StoreAppContext> GetListParam(Expression<Func<StoreAppContext, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).ToList();
        }

        public IEnumerable<StoreAppContext> GetResultSqlProc(string query, params object[] parameters)
        {
            if(parameters != null)
            {
                var results = _dbSet.FromSqlRaw(query, parameters).ToList();
                return results;
            }
            else
            {
                var results = _dbSet.FromSqlRaw(query).ToList();
                return results;
            }
        }

        public void InactiveAndDeletedByWhereClause(Expression<Func<StoreAppContext, bool>> wherePredict, Action<StoreAppContext> ForEachPredict)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public void Remove(StoreAppContext entity)
        {
            if (_DBEntity.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
                _DBEntity.SaveChanges();
            }
        }

        public void RemoveByWhereClause(Expression<Func<StoreAppContext, bool>> wherePredict)
        {
            StoreAppContext entity = _dbSet.Where(wherePredict).FirstOrDefault();
            Remove(entity);
        }

        public void RemoveRangeByWhereClause(Expression<Func<StoreAppContext, bool>> wherePredict)
        {
            List<StoreAppContext> entity = _dbSet.Where(wherePredict).ToList();
            foreach(var e in entity)
            {
                Remove(e);
            }
        }

        public void Update(StoreAppContext entity)
        {
            _dbSet.Attach(entity);
            _DBEntity.Entry(entity).State = EntityState.Modified;
            _DBEntity.SaveChanges();
        }

        public void UpdateByWhereClause(Expression<Func<StoreAppContext, bool>> wherePredict, Action<StoreAppContext> ForEachPredict)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public IEnumerable<StoreAppContext> GetResultsToShow(int PageNumber, int PageSize, int CurrentPage, Expression<Func<StoreAppContext, bool>> wherePredict, Expression<Func<StoreAppContext, int>> orderByPredict)
        {
            if (wherePredict != null)
            {
                return _dbSet.OrderBy(orderByPredict).Where(wherePredict).ToList();

            }
            else
            {
                return _dbSet.OrderBy(orderByPredict).ToList();
            }
        }
    }
}
