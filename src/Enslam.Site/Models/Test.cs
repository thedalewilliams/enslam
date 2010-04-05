using System;
using Castle.ActiveRecord;

namespace Enslam.Site.Models
{
    [ActiveRecord]
    public class Test : ActiveRecordBase<Test>
    {
        [PrimaryKey(PrimaryKeyType.GuidComb)]
        public Guid Id { get; private set; }


    }
}