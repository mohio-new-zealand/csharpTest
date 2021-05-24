using Microsoft.VisualStudio.TestTools.UnitTesting;
using MohioTechnicalBaseTest;
using System;
using System.Linq;

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

        [TestMethod]
        public void TestAddImmunisation()
        {
            var patient = new Patient(DateTime.Now);
            patient.AddImmunisation(new Immunisation()
            {
                ImmunisationId = 10,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now,
            });
            
            Assert.IsTrue(patient.Immunisations.Count() == 1);

            patient.AddImmunisation(new Immunisation()
            {
                ImmunisationId = 11,
                Vaccine = "Flu 65+",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            Assert.IsTrue(patient.Immunisations.Count() == 2);
        }

        [TestMethod]
        public void TestAddImmunisationDuplicate()
        {
            var patient = new Patient(DateTime.Now);
            var immunisation = new Immunisation()
            {
                ImmunisationId = 10,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now,
            };

            patient.AddImmunisation(immunisation);

            patient.AddImmunisation(immunisation);

            Assert.IsTrue(patient.Immunisations.Count() == 1);
        }

        [TestMethod]
        public void TestAddImmunisationSameId()
        {
            var patient = new Patient(DateTime.Now);

            patient.AddImmunisation(new Immunisation()
            {
                ImmunisationId = 10,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now,
            });

            patient.AddImmunisation(new Immunisation()
            {
                ImmunisationId = 10,
                Vaccine = "Flu 65+",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            Assert.IsTrue(patient.Immunisations.Count() == 1);
        }
    }
}
