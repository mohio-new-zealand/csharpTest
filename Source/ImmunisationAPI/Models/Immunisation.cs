using System;

namespace ImmunisationAPI.Models
{
    public class Immunisation : PatientImmunisation
    {
        public string Vaccine { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
