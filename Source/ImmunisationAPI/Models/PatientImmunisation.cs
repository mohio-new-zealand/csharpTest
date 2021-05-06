using System;

namespace ImmunisationAPI.Models
{
    public class PatientImmunisation
    {
        public Guid PatientId { get; set; }
        public Guid ImmunisationId { get; set; }
        public Outcome? Outcome { get; set; }
    }
}
