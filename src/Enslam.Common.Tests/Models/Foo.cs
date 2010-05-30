using Castle.ActiveRecord;
using Enslam.Common.Models;

namespace Enslam.Common.Tests.Models
{
    [ActiveRecord]
    public class Foo : Entity<Foo>
    {
        [Property]
        public virtual string Title { get; set; }
    }
}