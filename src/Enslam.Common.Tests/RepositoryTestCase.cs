using System;
using Castle.ActiveRecord;
using Enslam.Common.Repositories;
using Enslam.Common.Tests.Models;
using Moq;
using NUnit.Framework;

namespace Enslam.Common.Tests
{
    [TestFixture]
    public class RepositoryTestCase
    {
        [Test]
        public void TestSaveOnSubmitSavesWhenValid()
        {
            var mockFoo = new Mock<Foo>();
            var mockFooRepository = new Mock<Repository<Foo>> {CallBase = true};
            var mockFooValidator = new Mock<ActiveRecordValidator>(mockFoo);

            mockFooRepository
                .Setup(r => r.GetValidator(mockFoo.Object))
                .Returns(mockFooValidator.Object)
                .Verifiable();

            mockFooValidator
                .Setup(r => r.IsValid())
                .Returns(true)
                .Verifiable();

            mockFooRepository
                .Setup(r => r.Save(mockFoo.Object))
                .Verifiable();

            mockFooRepository
                .Object
                .SaveOnSubmit(mockFoo.Object);

            mockFooRepository.Verify();
        }

        [Test]
        public void TestSaveOnSubmitDoesNotSaveWhenInvalid()
        {
            var mockFoo = new Mock<Foo>();
            var mockFooRepository = new Mock<Repository<Foo>> { CallBase = true };
            var mockFooValidator = new Mock<ActiveRecordValidator>(mockFoo);

            mockFooRepository
                .Setup(r => r.GetValidator(mockFoo.Object))
                .Returns(mockFooValidator.Object)
                .Verifiable();

            mockFooValidator
                .Setup(r => r.IsValid())
                .Returns(false)
                .Verifiable();

            mockFooRepository
                .Object
                .SaveOnSubmit(mockFoo.Object);

            mockFooRepository.Verify();
            mockFooRepository.Verify(r => r.Save(mockFoo.Object), Times.Never());
        }
    }

    [TestFixture]
    public class ActiveRecordRepositoryTestCase : ActiveRecordTestCase
    {
        protected override void Init()
        {
            ActiveRecordStarter.Initialize(GetConfigSource(), typeof(Foo));
            Recreate();
        }

        [Test]
        public void TestGetByIdThrowsNotFoundException()
        {
            using (new SessionScope(FlushAction.Never))
            {
                var fooRepository = new Repository<Foo>();

                Guid id = Guid.NewGuid();

                Assert.Throws<NotFoundException>(() => fooRepository.GetById(id));
            }
        }

        [Test]
        public void TestGetByIdReturnsSavedEntity()
        {
            using (new SessionScope(FlushAction.Never))
            {
                IRepository<Foo> fooRepository = new Repository<Foo>();

                var entity = new Foo();

                ActiveRecordMediator.SaveAndFlush(entity);

                var foo = fooRepository.GetById(entity.Id);

                Assert.AreEqual(entity, foo);
            }
        }
    }
}
