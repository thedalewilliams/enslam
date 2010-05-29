using System;
using System.Linq;
using Enslam.Common.Models;

namespace Enslam.Common.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void SaveOnSubmit(TEntity entity);
        void DeleteOnSubmit(TEntity entity);
    }

    public interface IRepository
    {
        object GetById(Guid id);
        IQueryable GetAll();
        void SaveOnSubmit(object entity);
        void DeleteOnSubmit(object entity);
    }
}