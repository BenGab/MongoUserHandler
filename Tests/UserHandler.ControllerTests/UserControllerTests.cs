using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UserHandler.Db.Models;
using UserHandler.Repository;
using UserHandler.Web.Controllers;

namespace UserHandler.ControllerTests
{
    [TestFixture]
    public class UserControllerTests
    {
        private UsersController controller;
        private IRepository<User> userRepositoryMock;

        [SetUp]
        public void Setup()
        {
            userRepositoryMock = Substitute.For<IRepository<User>>();

            controller = new UsersController(userRepositoryMock);
        }

        [Test]
        public void GetAllPositveFlow()
        {
            List<User> returnvalues = new List<User>()
            {
                new User
                {
                    Id = 1
                },

                new User
                {
                    Id=2
                }
            };

            userRepositoryMock.GetAll().Returns(returnvalues);
            var result = controller.Get();
            CollectionAssert.AreEqual(returnvalues, result);
        }

        [Test]
        public void GetByIdPositiveFlow()
        {
            int id = 1;
            User returnvalue = new User
            {
                Id = 1
            };

            userRepositoryMock.GetById(Arg.Is(id)).Returns(returnvalue);
            var result = controller.Get(id);

            Assert.That(result, Is.EqualTo(returnvalue));
        }

        [Test]
        public void PostPostiveFlow()
        {
            User postValue = new User
            {
                Id = 1,
                UserName = "test"
            };

            controller.Post(postValue);
            userRepositoryMock.Received().Create(Arg.Is(postValue));
        }
    }
}
