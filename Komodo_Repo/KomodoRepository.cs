using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Repo
{
    public class KomodoRepository
    {

        private readonly Queue<Komodo> _komodoRepo = new Queue<Komodo>();

        public void NewClaim(Komodo newClaim)
        {
            _komodoRepo.Enqueue(newClaim);
        }

        public Queue<Komodo> GetClaimsList()
        {
            return _komodoRepo;
        }

        public bool ModifyClaim(int originalClaim, Komodo newClaim)
        {
            Komodo oldClaim = GetClaimByID(originalClaim);

            if (oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.Type = newClaim.Type;
                oldClaim.Description = newClaim.Description;
                oldClaim.Amount = newClaim.Amount;
                oldClaim.DateOfAccident = newClaim.DateOfAccident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                oldClaim.IsValid = newClaim.IsValid;

                return true;
            }
            else
            {
                return false;
            }
        }

        public Komodo GetClaimByID(int claimID)
        {
            foreach (Komodo komodoClaim in _komodoRepo)
            {
                if (komodoClaim.ClaimID == claimID)
                {
                    return komodoClaim;
                }


            }
            return null;
        }

        public void SeedClaimList()
        {
            Komodo claim1 = new Komodo(1, "House", "Tornado tore the roof off", 4847.00, new DateTime(2019, 2, 3), new DateTime(2019, 3, 3), true);
            Komodo claim2 = new Komodo(2, "Car", "Car spontaneously combusted", 19999.00, new DateTime(2020, 04, 06), new DateTime(2020, 05, 05), true);
            Komodo claim3 = new Komodo(3, "Personal Belongings", "Wii remote thrown through TV", 649.00, new DateTime(2020, 06, 06), new DateTime(2020, 08, 06), false);
            NewClaim(claim1);
            NewClaim(claim2);
            NewClaim(claim3);


        }
    }
}
