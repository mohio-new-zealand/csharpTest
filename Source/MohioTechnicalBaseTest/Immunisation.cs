using System;

namespace MohioTechnicalBaseTest
{
    public class Immunisation
    {
        /// <summary>
        /// Must be unique for Patient
        /// </summary>
        public Guid ImmunisationId { get; set; }

        public string Vaccine { get; set; }

        public Outcome? Outcome { get; set; }

        public DateTime CreatedDate { get; set; }

        public Immunisation()
        {

        }
        public Immunisation(Immunisation other, Boolean newId) // created copy-constructor with the choice to retain or create a new Id, to ensure interopertability with both the clone() and merge() functions
        {
            if (newId)
            {
                ImmunisationId = Guid.NewGuid();
            }
            else
            {
                ImmunisationId = other.ImmunisationId;
            }
            
            Vaccine = other.Vaccine;
            Outcome = other.Outcome;
            CreatedDate = other.CreatedDate;
        }
    }
}
