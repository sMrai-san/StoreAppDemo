using StoreApp.Data.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Data.Repositories
{
    public class GenericUnit: IDisposable
    {
        private StoreAppContext DBEntity = new StoreAppContext();

        private bool disposed = false;

        public IRepository<StoreAppContext> GetRepositoryInstance<StoreAppContext>() where StoreAppContext : class
        {
            return new GenericRepository<StoreAppContext>(DBEntity);
        }

        public void SaveChanges()
        {
            DBEntity.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DBEntity.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



    }
}
