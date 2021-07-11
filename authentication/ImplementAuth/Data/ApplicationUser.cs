using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ImplementAuth.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public DateTime CareerStarted { get; set; }


        [PersonalData]
        public bool EligibleBonus { get; set; }

        public ApplicationUser(): base()
        {

        }
    }
}
