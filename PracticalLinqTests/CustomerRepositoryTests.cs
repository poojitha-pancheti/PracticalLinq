using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PracticalLinq;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace PracticalLinq.Tests
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        public TestContext TestContext { get; set; }
        [TestMethod()]
        public void FindTestExistingCustomer()
        {
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();
            var result = repository.Find(customerList, 2);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Assert.AreEqual(2, result.CustomerId);
            Assert.AreEqual("Pancheti", result.LastName);
            Assert.AreEqual("Poojitha", result.FirstName);
        }

        [TestMethod()]
        public void FindTestNotFound()
        {
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();
            var result = repository.Find(customerList, 42);
            Assert.IsNull(result);
        }
    }
}