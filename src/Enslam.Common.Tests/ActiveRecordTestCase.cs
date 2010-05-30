using System;
using Castle.ActiveRecord;
using NUnit.Framework;
using Castle.ActiveRecord.Framework;

namespace Enslam.Common.Tests
{
    public abstract class ActiveRecordTestCase
	{
		protected static IConfigurationSource GetConfigSource()
		{
			return System.Configuration.ConfigurationManager.GetSection("activerecord") as IConfigurationSource;
		}

		protected static void Recreate()
		{
			ActiveRecordStarter.CreateSchema();
		}

        [SetUp]
        public void SetUp()
        {
            ActiveRecordStarter.ResetInitializationFlag();
            Init();
        }
		
		protected virtual void Init() {}

        [TearDown]
        public void TearDown()
        {
            try
            {
                ActiveRecordStarter.DropSchema();
            }
            catch (Exception)
            {

            }

            CleanUp();
        }

        protected virtual void CleanUp() {}
	}
}
