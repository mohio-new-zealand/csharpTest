using System;
using System.Collections.Generic;
using System.Linq;

namespace MohioTechnicalBaseTest
{
    public class Patient
    {
        private List<Immunisation> immunisationList = new List<Immunisation>();

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
            immunisationList.Add(immunisation);
        }

        public Immunisation Get(int immunisationId)
        {
            Immunisation patient = new Immunisation();
            foreach(var immunisation in immunisationList)
            {
                if(immunisation.ImmunisationId == immunisationId)
                {
                    patient = immunisation;
                }
                
            }

            return patient;
        }

        public void Remove(int immunisationId)
        {
            for(int i=0; i<= immunisationList.Count;i++)
            {
                if(immunisationList[i].ImmunisationId == immunisationId)
                {
                    immunisationList.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// The total count the Immunisation Status is Given and recored last month
        /// </summary>
        public decimal GetTotal()
        {
            int Count = 0;
           DateTime lastMonth = DateTime.Now.AddMonths(-1);
            foreach (var immunisation in immunisationList)
            {
                if (immunisation.CreatedDate.Month == lastMonth.Month && immunisation.Outcome == Outcome.Given)
                    {
                        Count++;
                    }
            }
            return Count;
           
        }

        /// <summary>
        /// Appends the ImmunisationList from the source to the current patient, immunisationId must be unique
        /// </summary>
        /// <param name="sourcePatient">patient to merge from</param>
        public void Merge(Patient sourcePatient)
        {
            foreach (var item in sourcePatient.immunisationList.ToList())
            {
                Immunisation patient = new Immunisation
                {
                    ImmunisationId = item.ImmunisationId,
                    Outcome = item.Outcome,
                    Vaccine = item.Vaccine,
                    CreatedDate = item.CreatedDate
                };
                sourcePatient.Add(patient);
            }
        }
        /// <summary>
        /// Creates a deep clone of the current Patient (all fields and properties)
        /// </summary>
        public Patient Clone()
        {
            return (Patient)this;
        }

        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Id: [Id], CreatedDate: [DD/MM/YYYY], ImmunisationListCount: [Number of items in ImmunisationList] 
        /// </summary>
        public override string ToString()
        {
            string patientrecord = "Id : " + this.Id + ", CreatedDate : " + this.CreatedDate + ", ImmunisationListCount : " + this.immunisationList.Count;
            return patientrecord;
        }
    }
}
