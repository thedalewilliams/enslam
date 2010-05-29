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

        public Type EntityType
        {
            get
            {
                return typeof(TEntity);
            }
        }

        public Repository()
        {

        }

        #region Implementation of IRepository<TEntity>

        TEntity IRepository<TEntity>.GetById(Guid id)
        {
            return ActiveRecordMediator<TEntity>.FindByPrimaryKey(id);
        }

        IQueryable<TEntity> IRepository<TEntity>.GetAll()
        {
            return ActiveRecordLinq.AsQueryable<TEntity>();
        }

        void IRepository<TEntity>.SaveOnSubmit(TEntity entity)
        {
            var validator = new ActiveRecordValidator(entity);
            if (validator.IsValid())
            {
                ActiveRecordMediator<TEntity>.Save(entity);
            }
        }

        void IRepository<TEntity>.DeleteOnSubmit(TEntity entity)
        {
            ActiveRecordMediator.Refresh(entity);
            ActiveRecordMediator.Delete(entity);
        }
        #endregion

        #region Implementation of IRepository

        object IRepository.GetById(Guid id)
        {
            return ActiveRecordMediator<TEntity>.FindByPrimaryKey(id);
        }

        IQueryable IRepository.GetAll()
        {
            return ActiveRecordLinq.AsQueryable<TEntity>();
        }

        void IRepository.SaveOnSubmit(object entity)
        {
            var validator = new ActiveRecordValidator(entity);
            if (validator.IsValid())
            {
                ActiveRecordMediator.Save(entity);
            }
        }

        void IRepository.DeleteOnSubmit(object entity)
        {
            ActiveRecordMediator.Delete(entity);
        }

        #endregion
    }
}