using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImmunisationAPI.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmunisationAPI.Models;

namespace ImmunisationAPI.repositories.Tests
{
    [TestClass()]
    public class PatientRepositoryTests : PatientRepository
    {
      
        [TestMethod]
        public void AddPatientTest()
        {
            var patient = new Patient();

            patient = AddPatient(patient).Value;
            Assert.IsNotNull(patient);

        }

        [TestMethod]
        public void ChangeOutComeStateTest()
        {
            var patientImmunisation = new PatientImmunisation();
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(1).CopyTo(bytes, 0);
            patientImmunisation.PatientId = new Guid(bytes);

            Assert.IsFalse(ChangeOutComeState(patientImmunisation).Value);
        }

    }
}