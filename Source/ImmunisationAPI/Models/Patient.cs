using System;
using System.Collections.Generic;

namespace ImmunisationAPI.Models
{
    public class Patient : PatientImmunisation
    {
        public List<Immunisation> ImmunisationList { get; set; } = new List<Immunisation>();

        /// <summary>
        /// Must not be allowed to change.
        /// </summary>
        public DateTime CreatedDate { get; set; }
        
    }
}
