using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFlightApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Priority(0)]
        public void LoginTest()
        {
            //Arrange
            var login_Test = new FlightApp.Login();

            //Act
            bool result = login_Test.DoLogin("admin", "admin");

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        [Priority(1)]
        public void FindFlightTest()
        {
            //Arrange
            var Find_Flight = new FlightApp.Booking();

            //Act
            Find_Flight.cmbFrom.Text = "Paris";
            Find_Flight.cmbTo.Text = "London";
            Find_Flight.cmbClass.Text = "Economy";
            Find_Flight.cmbTicket.Text = "1";
            bool result = Find_Flight.FlightSearch();

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        [Priority(2)]
        public void BookFlightTest()
        {
            Random rand1 = new Random();
            string order_num, ddate;
            int num1 = rand1.Next(1, 5000);
            int num2 = rand1.Next(1, 50);
            int a = num1 + num2;
            order_num = Convert.ToString(a);
            ddate = Convert.ToString(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            //Arrange
            var Book_Flight = new FlightApp.Booking();

            //Act
            Book_Flight.radioButton1.Checked = true;
            bool result = Book_Flight.BookSearch("ONE WAY", order_num, "London", "Paris", ddate, "FF001");

            //Assert
            Assert.IsTrue(result);
        }
    }
}
