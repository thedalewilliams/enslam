using System;
using System.Linq;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;
using Castle.Core.Logging;
using Enslam.Common.Models;

namespace Enslam.Common.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>, IRepository where TEntity : class, IEntity
    {
        private ILogger _logger = NullLogger.Instance;

        public virtual ILogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        public Repository()
        {

        }

        public TEntity GetById(Guid id)
        {
            return ActiveRecordMediator<TEntity>.FindByPrimaryKey(id);
        }

        public void SaveOnSubmit(object entity)
        {
            var validator = GetValidator(entity);
            if (validator.IsValid())
            {
                Save(entity);
            }
        }

        public virtual ActiveRecordValidator GetValidator(object entity)
        {
            return new ActiveRecordValidator(entity);
        }

        public virtual void Save(object entity)
        {
            ActiveRecordMediator.Save(entity);
        }

        #region Implementation of IRepository<TEntity>

        TEntity IRepository<TEntity>.GetById(Guid id)
        {
            return GetById(id);
        }

        IQueryable<TEntity> IRepository<TEntity>.GetAll()
        {
            return ActiveRecordLinq.AsQueryable<TEntity>();
        }

        void IRepository<TEntity>.SaveOnSubmit(TEntity entity)
        {
            SaveOnSubmit(entity);
        }

        void IRepository<TEntity>.DeleteOnSubmit(TEntity entity)
        {
            ActiveRecordMediator<TEntity>.Refresh(entity);
            ActiveRecordMediator<TEntity>.Delete(entity);
        }
        #endregion

        #region Implementation of IRepository

        object IRepository.GetById(Guid id)
        {
            return GetById(id);
        }

        IQueryable IRepository.GetAll()
        {
            return ActiveRecordLinq.AsQueryable<TEntity>();
        }

        void IRepository.SaveOnSubmit(object entity)
        {
            SaveOnSubmit(entity);
        }

        void IRepository.DeleteOnSubmit(object entity)
        {
            ActiveRecordMediator.Refresh(entity);
            ActiveRecordMediator.Delete(entity);
        }

        #endregion
    }
}