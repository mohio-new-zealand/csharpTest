using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohioTechnicalBaseTest
{
    class PatientTest // simple implementation of unit testing class for patient
    {

        public bool TestAdd()
        {
            Patient p1 = new Patient();
            Guid immunisation1 = Guid.NewGuid();
            Immunisation i1 = new Immunisation
            {
                ImmunisationId = immunisation1,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            };
            p1.Add(i1);
            if (p1.Get(immunisation1) == i1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TestGet()
        {
            Patient p1 = new Patient();
            Guid immunisation1 = Guid.NewGuid();
            Immunisation i1 = new Immunisation
            {
                ImmunisationId = immunisation1,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            };
            p1.Add(i1);
            if (p1.Get(immunisation1) == i1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TestRemove()
        {
            Patient p1 = new Patient();
            Guid immunisation1 = Guid.NewGuid();
            p1.Add(new Immunisation
            {
                ImmunisationId = immunisation1,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });
            p1.Remove(immunisation1);
            try
            {
                p1.Get(immunisation1);
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }
        public bool TestTotal()
        {
            Patient p1 = new Patient();
            Guid immunisation1 = Guid.NewGuid();
            p1.Add(new Immunisation
            {
                ImmunisationId = immunisation1,
                Vaccine = "Flu Vaccine PHO",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddMonths(-2)
            });

            Guid immunisation2 = Guid.NewGuid();
            p1.Add(new Immunisation
            {
                ImmunisationId = immunisation2,
                Vaccine = "Flu Vaccine PHO",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddMonths(-1)
            });

            Guid immunisation3 = Guid.NewGuid();
            p1.Add(new Immunisation
            {
                ImmunisationId = immunisation3,
                Vaccine = "Flu Vaccine PHO",
                Outcome = Outcome.AlternativeGiven,
                CreatedDate = DateTime.Now.AddDays(-5)
            });

            if (p1.GetTotal() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TestMerge()
        {
            Patient p1 = new Patient();
            Guid immunisation1 = Guid.NewGuid();
            p1.Add(new Immunisation
            {
                ImmunisationId = immunisation1,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddMonths(-1)
            });

            Patient p2 = new Patient();
            Guid immunisation2 = Guid.NewGuid();
            p2.Add(new Immunisation
            {
                ImmunisationId = immunisation2,
                Vaccine = "Flu 65+",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now.AddMonths(-1)
            });

            p1.Merge(p2);

            if (p1.GetTotal() == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TestClone()
        {
            Patient p1 = new Patient();
            Guid immunisation1 = Guid.NewGuid();
            p1.Add(new Immunisation
            {
                ImmunisationId = immunisation1,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });
            Patient p2 = p1.Clone();
            Immunisation originalImmunisation = p1.Get(immunisation1);
            Immunisation clonedImmunisation = p2.Get(immunisation1);
            if ((originalImmunisation != clonedImmunisation) & 
                    (originalImmunisation.Vaccine == clonedImmunisation.Vaccine) & 
                    (originalImmunisation.Outcome == clonedImmunisation.Outcome) & 
                    (originalImmunisation.CreatedDate == clonedImmunisation.CreatedDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TestToString()
        {
            Patient p1 = new Patient();
            Guid immunisation1 = Guid.NewGuid();
            p1.Add(new Immunisation
            {
                ImmunisationId = immunisation1,
                Vaccine = "Flu Diabetes",
                Outcome = Outcome.Given,
                CreatedDate = DateTime.Now
            });

            if (p1.ToString() == "Id: " + p1.Id.ToString() + ", CreatedDate: " + p1.CreatedDate.ToString() + ", ImmunisationListCount: 1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RunTests()
        {
            bool add = TestAdd();
            bool get = TestGet();
            bool remove = TestRemove();
            bool total = TestTotal();
            bool merge = TestMerge();
            bool clone = TestClone();
            bool str = TestToString();

            if (add & get & remove & total & merge & clone & str)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
