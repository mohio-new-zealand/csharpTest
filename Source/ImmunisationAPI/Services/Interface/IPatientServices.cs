using ImmunisationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ImmunisationAPI.Services.Interface
{
    public interface IPatientServices
    {
        ActionResult<Patient> GetPatientById(Guid patientId);
        ActionResult<Patient> AddImmunisation(PatientImmunisation patientImmunisation);
        ActionResult<Patient> AddPatient(Patient patient);
        ActionResult<Immunisation> GetImmunisationById(Guid immunusationId);
        ActionResult<Patient> RemoveImmunisation(PatientImmunisation patientImmunisation);
        ActionResult<Patient> Merge(Guid sourcePatientId, Guid targetPatientId);
        ActionResult<Patient> Clone(Guid patientId);
        ActionResult<bool> ChangeOutComeState(PatientImmunisation patientImmunisation);
        ActionResult<int> GetTotalImmuGiven(Guid immunusationId);
        ActionResult<string> PatientToString(Guid patientId);
    }
}
