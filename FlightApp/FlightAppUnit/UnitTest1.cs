using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightAppUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Priority(0)]
        public void logintest()
        {
            //Arrange
            var login_Test = new FlightApp.Login();

            //Act
            login_Test.txtUser.Text = "admin";
            login_Test.txtPass.Text = "admin";
            bool result = login_Test.dologin("admin", "admin");

            //Assert
            Assert.IsTrue(result);
        }
    }
}
