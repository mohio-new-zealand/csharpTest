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
        public Guid Id { get; set; } // changed to a Guid to ensure uniqueness

        /// <summary>
        /// Must not be allowed to change.
        /// </summary>
        public DateTime CreatedDate { get; } // removed settable property to ensure readonly status

        public Patient() // created default constructor to reflect changes to ID and CreatedDate fields
        {
            _immunisationList = new List<Immunisation>();
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        public Patient(Patient other) // copy-constructor deep copies all immunisations (although retains their Id, in order to preserve functionality of get() function)
        {
            _immunisationList = new List<Immunisation>();
            foreach (Immunisation i in other._immunisationList){
                Immunisation copy = new Immunisation(i, false);
                _immunisationList.Add(copy);
            }
            Id = other.Id;
            CreatedDate = other.CreatedDate;
        }

        public void Add(Immunisation immunisation)
        {
            _immunisationList.Add(immunisation);
        }

        public Immunisation Get(Guid immunisationId)
        {
            foreach (Immunisation i in _immunisationList)
            {
                if (i.ImmunisationId == immunisationId)
                {
                    return i;
                }
            }
            throw new Exception();
        }

        public void Remove(Guid immunisationId)
        {
            foreach (Immunisation i in _immunisationList)
            {
                if (i.ImmunisationId == immunisationId)
                {
                    _immunisationList.Remove(i);
                    break;
                }
            }
            
        }

        /// <summary>
        /// The total count the Immunisation Status is Given and recored last month
        /// </summary>
        public decimal GetTotal()
        {
            int count = 0;
            foreach (Immunisation i in _immunisationList)
            {
                if (i.Outcome == Outcome.Given & i.CreatedDate.Month == DateTime.Now.AddMonths(-1).Month)
                {
                    count ++;
                }
            }
            return count;
        }

        /// <summary>
        /// Appends the ImmunisationList from the source to the current patient, immunisationId must be unique
        /// </summary>
        /// <param name="sourcePatient">patient to merge from</param>
        public void Merge(Patient sourcePatient) // creates copies of all immunnisations in sourcePatient with new Ids
        {
            foreach (Immunisation i in sourcePatient._immunisationList)
            {
                Immunisation copy = new Immunisation(i, true);
                _immunisationList.Add(copy);
            }
            
        }

        /// <summary>
        /// Creates a deep clone of the current Patient (all fields and properties)
        /// </summary>
        public Patient Clone() // outsources work of copying to copy-constructor
        {
            return new Patient(this);
        }

        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Id: [Id], CreatedDate: [DD/MM/YYYY], ImmunisationListCount: [Number of items in ImmunisationList] 
        /// </summary>
        public override string ToString()
        {
            return "Id: " + Id.ToString() + ", CreatedDate: " + CreatedDate.ToString() + ", ImmunisationListCount: " + _immunisationList.Count.ToString();
        }
    }
}
