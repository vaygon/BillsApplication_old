using BillsApplicationDomain;
using BillsApplicationDomain.Repository;
using BillsApplicationDomain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsApplication.Tests.ServiceTests
{
    [TestClass]
    public class BillServiceTests
    {

        public BillServiceTests()
        { 
        }

        [TestMethod]
        public void GetBills_ReturnsListOfBills()
        {
            var repo = new Mock<IGenericRepository>();

            var listOfBill = new List<Bill>() { 
                new Bill
                {
                    Id = 1
                }
            };

            repo.Setup(x => x.FindAll<Bill>()).Returns(listOfBill.AsQueryable);

            var billservice = new BillService(repo.Object);

            Assert.IsTrue(billservice.GetBills().Count() == 1);
        }

        [TestMethod]
        public void AddBill_Succcess()
        {
            var repo = new Mock<IGenericRepository>();

            var newBill = new Bill()
            {
                Name = "Lee"
            };

            repo.Setup(x => x.Create<Bill>(It.IsAny<Bill>())).Verifiable();

            var service = new BillService(repo.Object);

            service.Add(newBill);

            repo.Verify();
            
        }

    }
}
