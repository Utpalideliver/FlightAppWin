using System;

using NUnit.Framework;

namespace FlightAppUnit
{
    [TestFixture]
    public class UnitTest1
    {
        [Test, Order(1)]
        public void logintest()
        {
            //Arrange
            var login_Test = new FlightApp.Login();

            //Act
            login_Test.txtUser.Text = "admin";
            login_Test.txtPass.Text = "admin";
            bool result = login_Test.dologin("admin", "admin");

            //Assert
            NUnit.Framework.Assert.IsTrue(result);
        }
    }
}
