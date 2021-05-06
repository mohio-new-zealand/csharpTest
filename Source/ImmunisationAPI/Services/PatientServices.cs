using ImmunisationAPI.Repositories.Interface;
using ImmunisationAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using ImmunisationAPI.Models;

namespace ImmunisationAPI.Services
{
    public class PatientServices : IPatientServices
    {

        private readonly IPatientRepository _patientRepository;

        // inversion of controll
        public PatientServices(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public ActionResult<Patient> GetPatientById(Guid patientId)
        {
            return _patientRepository.GetPatientById(patientId);
        }

        public ActionResult<Patient> AddImmunisation(PatientImmunisation patientImmunisation)
        {
            return _patientRepository.AddImmunisationToPatient(patientImmunisation);
        }

        public ActionResult<Patient> AddPatient(Patient patient)
        {
            return _patientRepository.AddPatient(patient);
        }
        public ActionResult<Immunisation> GetImmunisationById(Guid immunisationId)
        {
            return _patientRepository.GetImmunisationById(immunisationId);
        }

        public ActionResult<Patient> RemoveImmunisation(PatientImmunisation patientImmunisation)
        {
           return _patientRepository.RemoveImmunisation(patientImmunisation);
        }

        public ActionResult<Patient> Merge(Guid sourcePatientId, Guid targetPatientId)
        {
            return Merge(sourcePatientId, targetPatientId);
        }

        public ActionResult<Patient> Clone(Guid patientId)
        {
            return Clone(patientId);
        }

        public ActionResult<bool> ChangeOutComeState(PatientImmunisation patientImmunisation)
        {
            return ChangeOutComeState(patientImmunisation);
        }
        
        public ActionResult<int> GetTotalImmuGiven(Guid immunusationId)
        {
            return GetTotalImmuGiven(immunusationId);
        }

        public ActionResult<string> PatientToString(Guid patientId)
        {
            return PatientToString(patientId);
        }



        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Id: [Id]-- xxeaweqweqw, CreatedDate: [DD/MM/YYYY] 02/03/2021, ImmunisationListCount: [Number of items in ImmunisationList] 20
        /// </summary>
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
