using System;

namespace MohioTechnicalBaseTest
{
    public class Immunisation
    {
        /// <summary>
        /// Must be unique for Patient
        /// </summary>
        public int ImmunisationId { get; set; }

        public string Vaccine { get; set; }

        public Outcome? Outcome { get; set; }

        public DateTime CreatedDate { get; set; }

        public Immunisation Clone()
        {
            return new Immunisation()
            {
                ImmunisationId = ImmunisationId,
                Vaccine = Vaccine,
                Outcome = Outcome,
                CreatedDate = CreatedDate,
            };
        }
    }
}
