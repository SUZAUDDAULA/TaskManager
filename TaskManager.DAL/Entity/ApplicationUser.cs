using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DAL.Entity
{
    public class ApplicationUser: IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string gender { get; set; }
        public bool receiveNewsLetters { get; set; }
        public int? isActive { get; set; }

        public int? countryId { get; set; }
        [NotMapped]
        public string Token { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
