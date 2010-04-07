using System;
using Castle.ActiveRecord;
using Enslam.Common.Models;

namespace Enslam.Site.Models
{
    [ActiveRecord]
    public class Test : Entity<Test>
    {
        [Property]
        public virtual string Heh { get; set; }
    }
}