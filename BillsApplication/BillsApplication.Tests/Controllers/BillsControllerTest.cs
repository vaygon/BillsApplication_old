using BillsApplication.Controllers;
using BillsApplicationDomain;
using BillsApplicationDomain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BillsApplication.Tests.Controllers
{
    [TestClass]
    public class BillsControllerTest
    {
        [TestMethod]
        public void IndexReturnsView()
        { 
            // Arrange
            var service = new Mock<IBillService>();
            

            var listOfBills = new List<Bill>
            {
                new Bill
                {
                    Id = 1,
                    Name = "Test1",
                    DueDay = 1,
                    Amount = 1.00,
                    User = "Lee",
                    Tag = Tag.Housing

                },
                new Bill
                {
                    Id = 2,
                    Name = "Test2",
                    DueDay = 2,
                    Amount = 3.00,
                    User = "John",
                    Tag = Tag.Utility

                }
            };

            service.Setup(x => x.GetBills()).Returns(listOfBills);

            var controller = new BillController(service.Object);

            // Act

            var result = controller.Index();

            // Assert

            Assert.IsNotNull(result);
        }
    }
}
