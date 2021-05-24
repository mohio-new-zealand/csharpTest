using Microsoft.VisualStudio.TestTools.UnitTesting;
using MohioTechnicalBaseTest;
using System;

namespace MohioTechnicalBaseTestUnitTest
{
    [TestClass]
    public class PatientTest
    {
        [TestMethod]
        public void TestConstrutor()
        {
            var createDate = DateTime.Now;
            var patient = new Patient(createDate);
            Assert.IsTrue(patient.CreatedDate == createDate, "Create date should use date passed in constructor.");
        }
    }
}
