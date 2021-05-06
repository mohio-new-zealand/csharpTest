using System;
using System.Collections.Generic;
using System.Linq;
using ImmunisationAPI.Models;
using ImmunisationAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ImmunisationAPI.repositories
{
    public class PatientRepository : IPatientRepository
    {
        private List<Patient> _patientList = new List<Patient>();
        private List<Immunisation> _immunisationList = new List<Immunisation>();
        public PatientRepository()
        {
            _patientList = CreateMultiplePatients();
            _immunisationList = CreatImmunisations();
        }

        public ActionResult<Patient> GetPatientById(Guid patientId)
        {
            var patient = _patientList.SingleOrDefault(p => p.PatientId == patientId);
            return patient;
        }

        public ActionResult<Patient> AddImmunisationToPatient(PatientImmunisation patientImmunisation)
        {
            var patient = GetPatientById(patientImmunisation.PatientId).Value;
            var immunisation = GetImmunisationById(patientImmunisation.ImmunisationId).Value;
            immunisation.CreatedDate = DateTime.Now;
            immunisation.Outcome = Outcome.Given;
            immunisation.IsActive = true;

            patient.ImmunisationList.Add(immunisation);
            return patient;
        }

        public ActionResult<Patient> AddPatient(Patient patient)
        {
            patient.CreatedDate = DateTime.Now;
            _patientList.Add(patient);

            return patient;
        }

        public ActionResult<Immunisation> GetImmunisationById(Guid immunusationId)
        {
            var immunusation = _immunisationList.Find(p => p.ImmunisationId == immunusationId);

            return immunusation;
        }

        public ActionResult<Patient> RemoveImmunisation(PatientImmunisation patientImmunisation)
        {
            var patient = GetPatientById(patientImmunisation.PatientId).Value;
            var immunisationIndex = patient.ImmunisationList.FindIndex(i => i.ImmunisationId == patientImmunisation.ImmunisationId);

            if (immunisationIndex != -1)
            {
                patient.ImmunisationList[immunisationIndex].IsActive = false;
            }

            return patient;
        }

        private void RemovePatient(Patient patient)
        {
            _patientList.Remove(patient);
        }

        public ActionResult<bool> ChangeOutComeState(PatientImmunisation patientImmunisation)
        {
            var patient = GetPatientById(patientImmunisation.PatientId).Value;

            var immunisationIndex =  patient.ImmunisationList.FindIndex(i => i.ImmunisationId == patientImmunisation.ImmunisationId);

            if(immunisationIndex != -1)
            {
                patient.ImmunisationList[immunisationIndex].Outcome = patientImmunisation.Outcome;
            }

            return false;
        }

        public ActionResult<Patient> Merge(Guid sourcePatientId, Guid targetPatientId)
        {
            var sourcePatient= GetPatientById(sourcePatientId).Value;
            var targetPatient = GetPatientById(targetPatientId).Value;

            targetPatient.PatientId = sourcePatient.PatientId;
            targetPatient.CreatedDate = sourcePatient.CreatedDate;
           
            foreach (var immunisation in sourcePatient.ImmunisationList)
            {
                if (!targetPatient.ImmunisationList.Contains(immunisation))
                {
                    targetPatient.ImmunisationList.Add(immunisation);
                }
            }

            // set sourcePatient to be inactive

            return targetPatient;
        }

        public ActionResult<Patient> Clone(Guid patientId)
        {
            var patient = GetPatientById(patientId).Value;

            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, patient);
                ms.Position = 0;

                return (Patient)formatter.Deserialize(ms);
            }

        }

        public ActionResult<int> GetTotalImmuGiven(Guid immunusationId)
        {
            int count = 0;

            foreach (var patient in _patientList)
            {
                var immuCount = patient.ImmunisationList.Where(i => i.ImmunisationId == immunusationId && i.Outcome == Outcome.Given).ToList().Count;
                count += immuCount;
            }
            return count;
        }

        public ActionResult<string> PatientToString(Guid patientId)
        {
            var patient = GetPatientById(patientId).Value;

            var immuCount = patient.ImmunisationList.Count();

            return $"Id: {patient.PatientId}, CreatedDate: {patient.CreatedDate.ToString("dd/MM/YYYY")}, ImmunisationListCount: {immuCount}";
        }

        private static List<Immunisation> CreatImmunisations()
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(11).CopyTo(bytes, 0);
            var Immunisations = new List<Immunisation>();

            var immunisation = new Immunisation
            {
                ImmunisationId = new Guid(bytes),
                Vaccine = "Flu 65+",
                Outcome = Outcome.NonResponder,
                CreatedDate = DateTime.Now,
                IsActive = false
            };
            Immunisations.Add(immunisation);

            BitConverter.GetBytes(12).CopyTo(bytes, 0);
            immunisation = new Immunisation
            {
                ImmunisationId = new Guid(bytes),
                Vaccine = "Flu Vaccine PHO",
                Outcome = Outcome.NonResponder,
                CreatedDate = DateTime.Now.AddMonths(-2),
                IsActive = false
            };
            Immunisations.Add(immunisation);

            BitConverter.GetBytes(13).CopyTo(bytes, 0);
            immunisation = new Immunisation
            {
                ImmunisationId = new Guid(bytes),
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.NonResponder,
                CreatedDate = DateTime.Now,
                IsActive = false
            };
            Immunisations.Add(immunisation);

            return Immunisations;
        }

        private static List<Patient> CreateMultiplePatients()
        {
            List<Patient> patientList = new List<Patient>();
            for (var i = 1; i < 10; i++)
            {
                byte[] bytes = new byte[16];
                BitConverter.GetBytes(i).CopyTo(bytes, 0);

                var patient = new Patient
                {
                    PatientId = new Guid(bytes),
                    CreatedDate = DateTime.Now
                };

                patientList.Add(patient);

            }

            return patientList;
        }
    }

}
