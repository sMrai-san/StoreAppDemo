using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreApp.Data.Repositories
{
    public interface IRepository<StoreAppContext> where StoreAppContext:class
    {
        IEnumerable<StoreAppContext> GetAllContents();
        IEnumerable<StoreAppContext> GetListParam(Expression<Func<StoreAppContext, bool>> wherePredict);
        IEnumerable<StoreAppContext> GetResultSqlProc(string query, params object[] parameters);
        IEnumerable<StoreAppContext> GetResultsToShow(int PageNumber, int PageSize, int CurrentPage, Expression<Func<StoreAppContext, bool>> wherePredict, Expression<Func<StoreAppContext, int>> orderByPredict);
        
        IQueryable<StoreAppContext> GetAllContentsIQueryable();

        int GetAllContentCount();

        void Add(StoreAppContext entity);
        void Update(StoreAppContext entity);
        void UpdateByWhereClause(Expression<Func<StoreAppContext, bool>> wherePredict, Action<StoreAppContext> ForEachPredict);
        StoreAppContext GetFirstOrDefault(int contentId);
        void Remove(StoreAppContext entity);
        void RemoveByWhereClause(Expression<Func<StoreAppContext, bool>> wherePredict);
        void RemoveRangeByWhereClause(Expression<Func<StoreAppContext, bool>> wherePredict);
        void InactiveAndDeletedByWhereClause(Expression<Func<StoreAppContext, bool>> wherePredict, Action<StoreAppContext> ForEachPredict);

        StoreAppContext GetFirstOrDefaultByParam(Expression<Func<StoreAppContext, bool>> wherePredict);
       
    }
}
