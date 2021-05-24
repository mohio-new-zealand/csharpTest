using System;
using System.Collections.Generic;
using System.Linq;

namespace MohioTechnicalBaseTest
{
    public class Patient
    {
        private static int NextPatientId = 100;

        private readonly List<Immunisation> _immunisationList = new();

        public Patient(DateTime createdDate)
        {
            Id = GenerateNewId();
            CreatedDate = createdDate;
        }

        private static string GetImmunisationNotFoundErrorMessage(int immunistionId) => $"This patient doesn't have an immunisation with id \"{immunistionId}\"";

        /// <summary>
        /// Must be unique. 
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Must not be allowed to change.
        /// </summary>
        public DateTime CreatedDate { get; }
        
        public IEnumerable<Immunisation> Immunisations { get => _immunisationList; }

        /// <summary>
        /// Adds the immunisation to the list of immunisations, if it isn't already contained.
        /// </summary>
        /// <param name="immunisation"></param>
        public void AddImmunisation(Immunisation immunisation)
        {
            _immunisationList.Add(immunisation);
        }

        /// <summary>
        /// Gets the immunisation of this patient with the given id. Throws if not found.
        /// </summary>
        /// <param name="immunisationId"></param>
        /// <returns></returns>
        public Immunisation GetImmunisation(int immunisationId)
        {
            var immunisation = Immunisations.FirstOrDefault(imm => imm.ImmunisationId == immunisationId);
            if (immunisation == null) throw new ArgumentException(GetImmunisationNotFoundErrorMessage(immunisationId), nameof(immunisationId));
            return immunisation;
        }

        /// <summary>
        /// Removes the immunisation of the given id from this patient. Throws if not found.
        /// </summary>
        /// <param name="immunisationId"></param>
        /// <returns>The immunisation that was removed.</returns>
        public Immunisation RemoveImmunisation(int immunisationId)
        {
            var immunisation = Immunisations.FirstOrDefault(imm => imm.ImmunisationId == immunisationId);
            if (immunisation == null) throw new ArgumentException(GetImmunisationNotFoundErrorMessage(immunisationId), nameof(immunisationId));
            if (_immunisationList.Remove(immunisation))
            {
                return immunisation;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the total count of immunisations with an outcome of Given and recored within one month
        /// </summary>
        public int GetRecentGivenImmunisationCount()
        {
            var startDate = DateTime.Today.AddMonths(-1);
            return Immunisations.Count(imm => imm.Outcome == Outcome.Given && imm.CreatedDate >= startDate);
        }

        /// <summary>
        /// Appends the ImmunisationList from the source to the current patient, skips immunisations with duplicate ids.
        /// </summary>
        /// <param name="sourcePatient">patient to merge from</param>
        public void Merge(Patient sourcePatient)
        {
            foreach(var immunisation in sourcePatient.Immunisations)
            {
                if (Immunisations.Any(imm => imm.ImmunisationId == immunisation.ImmunisationId))
                {
                    // 24/05/2021 CJ
                    // Generate new ids? Skip adding them? Throw an error?
                    // Chosen to skip duplicate ids, this may need to change depending on where ids are stored and if it's correct to generate new ids.
                    continue;
                }
                else
                {
                    _immunisationList.Add(immunisation);
                }
            }
        }

        /// <summary>
        /// Creates a deep clone of the current Patient (all fields and properties). Note the cloned patient will have a new id.
        /// </summary>
        public Patient Clone()
        {
            var clonedId = GenerateNewId();
            var clonedPatient = new Patient(this.CreatedDate);
            foreach (var immunisation in this.Immunisations)
            {
                clonedPatient.AddImmunisation(immunisation.Clone());
            }
            return clonedPatient;
        }

        private static int GenerateNewId() => NextPatientId++;

        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Id: [Id], CreatedDate: [DD/MM/YYYY], ImmunisationListCount: [Number of items in ImmunisationList] 
        /// </summary>
        public override string ToString()
        {
            return $"Id: {Id}, CreatedDate: {CreatedDate:dd/MM/yyyy}, ImmunisationListCount: {Immunisations.Count()}";
        }
    }
}
