using System;
using Castle.ActiveRecord;

namespace Enslam.Common.Models
{
    public abstract class Entity<TEntity> : IEntity where TEntity : class, IEntity
    {
        [PrimaryKey(PrimaryKeyType.GuidComb)]
        public virtual Guid Id { get; set; }

        [Version]
        public virtual Int32 Version { get; set; }


        /// <summary>
        /// NHibernate requires GetHashCode in order to manage entity cacheing
        /// This is the simplest possible implementation, see the following post for a more
        /// detailed approach:
        /// http://devlicio.us/blogs/billy_mccafferty/archive/2007/04/25/using-equals-gethashcode-effectively.aspx
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // this expression might overflow, but it doesn't matter since the resulting negative 
            // value is still a valid hash code.
            return typeof(TEntity).GetHashCode() + Id.GetHashCode();
        }

        /// <summary>
        /// NHibernate requires Equals in order to manage entity cacheing
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var otherEntity = obj as TEntity;
            if (otherEntity == null) return false;
            return otherEntity.Id == Id;
        }
    }
}