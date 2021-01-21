using System;
using System.Collections.Generic;

namespace MohioTechnicalBaseTest
{
    public class Patient
    {
        private List<Immunisation> _immunisationList;

        /// <summary>
        /// Must be unique
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Must not be allowed to change.
        /// </summary>
        public DateTime CreatedDate { get; set; }
        
        public void Add(Immunisation immunisation)
        {
            _immunisationList.Add(immunisation)
        }

        public Immunisation Get(int immunisationId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int immunisationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The total count the Immunisation Status is Given and recored last month
        /// </summary>
        public decimal GetTotal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Appends the ImmunisationList from the source to the current patient, immunisationId must be unique
        /// </summary>
        /// <param name="sourcePatient">patient to merge from</param>
        public void Merge(Patient sourcePatient)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a deep clone of the current Patient (all fields and properties)
        /// </summary>
        public Patient Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Id: [Id], CreatedDate: [DD/MM/YYYY], ImmunisationListCount: [Number of items in ImmunisationList] 
        /// </summary>
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
