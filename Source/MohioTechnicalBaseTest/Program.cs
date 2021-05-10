/*
    Welcome to the Mohio technical Test 1
    ---------------------------------------------------------------------------------
    This test contains a small patient application that has several issues.

    Please fix them and execute each method below.
	
    Rules
    ---------------------------------------------------------------------------------
    1. The entire solution must be written in C# .net5
    2. Please modify the solution anyway you prefer. 
        a. You can modify classes, rename and add methods, change property types, add projects 
        b. Use libraries or frameworks (must be .net based)
    3. Write tests
 
    Show your skills


    Good luck 

    When you have finished the solution please do a pull request to original repository (push only the necessary files)
*/

using System;
using System.Linq;

namespace MohioTechnicalBaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mohio Technical Test 1");

            CreatePatientWithOneImmunisation();
            CreatePatientWithMultipleImmunisation();
            RemoveImmunisation();
            MergePatients();
            ClonePatient();
            PatientToString();
            PatientTest test = new PatientTest();
            bool result = test.RunTests();
            if (result)
            {
                Console.WriteLine("All tests passed!");
            }
            else
            {
                Console.WriteLine("One or more tests failed!");
            }
        }
        
        private static void CreatePatientWithOneImmunisation()
        {
            var patient = new Patient();

            patient.Add(new Immunisation
            {
                ImmunisationId = Guid.NewGuid(),
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            Console.WriteLine(patient.GetTotal());
        }

        private static void CreatePatientWithMultipleImmunisation()
        {
            var patient = new Patient();

            patient.Add(new Immunisation
            {
                ImmunisationId = Guid.NewGuid(),
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            patient.Add(new Immunisation
            {
                ImmunisationId = Guid.NewGuid(),
                Vaccine = "Flu 65+",
                Outcome = Outcome.NonResponder,
                CreatedDate = DateTime.Now
            });

            patient.Add(new Immunisation
            {
                ImmunisationId = Guid.NewGuid(),
                Vaccine = "Flu Vaccine PHO",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddMonths(-2)
            });

            Console.WriteLine(patient.GetTotal());
        }

        private static void RemoveImmunisation()
        {
            var patient = new Patient();

            Guid immunisation1 = Guid.NewGuid();
            Guid immunisation2 = Guid.NewGuid();
            Guid immunisation3 = Guid.NewGuid();

            patient.Add(new Immunisation
            {
                ImmunisationId = immunisation1,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            patient.Add(new Immunisation
            {
                ImmunisationId = immunisation2,
                Vaccine = "Flu 65+",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddDays(-15)
            });

            patient.Add(new Immunisation
            {
                ImmunisationId = immunisation3,
                Vaccine = "Flu Vaccine PHO",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddMonths(-2)
            });

            patient.Remove(immunisation1);
            Console.WriteLine(patient.GetTotal());
        }

        private static void MergePatients()
        {
            var patient1 = new Patient();

            patient1.Add(new Immunisation
            {
                ImmunisationId = Guid.NewGuid(),
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            var patient2 = new Patient();

            patient2.Add(new Immunisation
            {
                ImmunisationId = Guid.NewGuid(),
                Vaccine = "Flu 65+",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddDays(-15)
            });

            patient1.Merge(patient2);
            Console.WriteLine(patient1.GetTotal());
        }

        private static void ClonePatient()
        {
            var patient1 = new Patient();

            Guid immunisation1 = Guid.NewGuid();

            patient1.Add(new Immunisation
            {
                ImmunisationId = immunisation1,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddDays(-15)
            });

            var patient2 = patient1.Clone();

            patient2.Get(immunisation1).Outcome = Outcome.AlternativeGiven;

            Console.WriteLine(patient1.GetTotal());
            Console.WriteLine(patient2.GetTotal());
        }

        private static void PatientToString()
        {
            var patient = new Patient();

            patient.Add(new Immunisation
            {
                ImmunisationId = Guid.NewGuid(),
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            patient.Add(new Immunisation
            {
                ImmunisationId = Guid.NewGuid(),
                Vaccine = "Flu Vaccine PHO",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddMonths(-2)
            });

            Console.WriteLine(patient.ToString());
        }
    }
}
