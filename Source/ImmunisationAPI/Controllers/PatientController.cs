using ImmunisationAPI.Models;
using ImmunisationAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ImmunisationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _patientServices;

        // inversion of controll
        public PatientController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }

        [HttpGet]
        [Route("GetPatientById")]
        public ActionResult<Patient> GetPatientById(Guid patientId)
        {
            try
            {
                if (patientId == Guid.Empty)
                {
                    return BadRequest();
                }

                return _patientServices.GetPatientById(patientId);
            }
            catch (Exception ex) {
                return Problem(ex.Message, title: $"There was an error on get patient");
            }
        }
        
        [HttpPut]
        [Route("AddImmunisation")]
        public ActionResult<Patient> AddImmunisation(PatientImmunisation patientImmunisation)
        {
            try
            {
                if (patientImmunisation.PatientId == Guid.Empty || patientImmunisation.ImmunisationId == Guid.Empty)
                {
                    return BadRequest();
                }

                return _patientServices.AddImmunisation(patientImmunisation);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, title: $"There was an error on add immunisation");
            }
        }

        [HttpPut]
        [Route("AddPatient")]
        public ActionResult<Patient> AddPatient(Patient patient)
        {
            try
            {
                if (patient == null)
                {
                    return BadRequest();
                }

                return _patientServices.AddPatient(patient);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, title: $"There was an error on add patient");
            }
        }

        [HttpPut]
        [Route("RemoveImmunisation")]
        public ActionResult<Patient> RemoveImmunisation(PatientImmunisation patientImmunisation)
        {
            try
            {
                if (patientImmunisation.PatientId == Guid.Empty || patientImmunisation.ImmunisationId == Guid.Empty)
                {
                    return BadRequest();
                }
                return _patientServices.RemoveImmunisation(patientImmunisation);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message, title: $"There was an error on remove immunisation");
            }
        }

        [HttpPut]
        [Route("MergePatientById")]
        public ActionResult<Patient> Merge(Guid sourcePatientId, Guid targetPatientId)
        {
            try
            {
                if (sourcePatientId == Guid.Empty || targetPatientId == Guid.Empty)
                {
                    return BadRequest();
                }

                // ToDO add comment should check patient existing
                return _patientServices.Merge(sourcePatientId, targetPatientId);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, title: $"There was an error on merge patients");
            }
        }
        
        [HttpPut]
        [Route("ClonPatientById")]
        public ActionResult<Patient> Clone(Guid patientId)
        {
            try
            {
                if (patientId == Guid.Empty)
                {
                    return BadRequest();
                }
                return _patientServices.Clone(patientId);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, title: $"There was an error on clone patient");
            }
        }

        [HttpPut]
        [Route("ChangeOutCome")]
        public ActionResult<bool> ChangeOutComeState(PatientImmunisation patientImmunisation)
        {
            try
            {
                if (patientImmunisation.PatientId == Guid.Empty || patientImmunisation.ImmunisationId == Guid.Empty || !Enum.IsDefined(typeof(Outcome), patientImmunisation.Outcome.Value))
                {
                    return BadRequest();
                }
                return _patientServices.ChangeOutComeState(patientImmunisation);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, title: $"There was an error on change outcome state");
            }
        }

        [HttpGet]
        [Route("GetImmunisationCount")]
        ActionResult<int> GetTotalImmuGiven(Guid immunusationId)
        {
            try
            {
                if (immunusationId == Guid.Empty)
                {
                    return BadRequest();
                }

                return _patientServices.GetTotalImmuGiven(immunusationId);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, title: $"There was an error on get immunisation count");
            }
        }

        [HttpGet]
        [Route("GetPatientToString")]
        ActionResult<string> PatientToString(Guid patientId)
        {
            try
            {
                if (patientId == Guid.Empty)
                {
                    return BadRequest();
                }

                return _patientServices.PatientToString(patientId);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, title: $"There was an error on get patient info ToString");
            }
        }
    }
}
