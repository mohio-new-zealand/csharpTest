﻿/*
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
        }
        
        private static void CreatePatientWithOneImmunisation()
        {
            var patient = new Patient
            {
                Id = 100,
                CreatedDate = DateTime.Now
            };

            patient.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            Console.WriteLine(patient.GetTotal());
        }

        private static void CreatePatientWithMultipleImmunisation()
        {
            var patient = new Patient
            {
                Id = 100,
                CreatedDate = DateTime.Now
            };

            patient.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            patient.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu 65+",
                Outcome = Outcome.NonResponder,
                CreatedDate = DateTime.Now
            });

            patient.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu Vaccine PHO",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddMonths(-2)
            });

            Console.WriteLine(patient.GetTotal());
        }

        private static void RemoveImmunisation()
        {
            var patient = new Patient
            {
                Id = 100,
                CreatedDate = DateTime.Now
            };

            patient.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            patient.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu 65+",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddDays(-15)
            });

            patient.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu Vaccine PHO",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddMonths(-2)
            });

            patient.Remove(10);
            Console.WriteLine(patient.GetTotal());
        }

        private static void MergePatients()
        {
            var patient1 = new Patient
            {
                Id = 100,
                CreatedDate = DateTime.Now
            };

            patient1.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            var patient2 = new Patient
            {
                Id = 100,
                CreatedDate = DateTime.Now
            };

            patient2.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu 65+",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddDays(-15)
            });

            patient1.Merge(patient2);
            Console.WriteLine(patient1.GetTotal());
        }

        private static void ClonePatient()
        {
            var patient1 = new Patient
            {
                Id = 100,
                CreatedDate = DateTime.Now
            };

            patient1.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            var patient2 = patient1.Clone();

            patient2.Get(10).Outcome = Outcome.AlternativeGiven;

            Console.WriteLine(patient1.GetTotal());
            Console.WriteLine(patient2.GetTotal());
        }

        private static void PatientToString()
        {
            var patient = new Patient
            {
                Id = 100,
                CreatedDate = DateTime.Now
            };

            patient.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            patient.Add(new Immunisation
            {
                ImmunisationId = 10,
                Vaccine = "Flu Vaccine PHO",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddMonths(-2)
            });

            Console.WriteLine(patient.ToString());
        }
    }
}
