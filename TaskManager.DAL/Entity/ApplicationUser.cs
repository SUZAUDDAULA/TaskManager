using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.DAL.Entity.Auth;

namespace TaskManager.DAL.Entity
{
    public class ApplicationUser: IdentityUser
    {
        public int? userTypeId { get; set; }
        public UserType userType { get; set; }
        public int? isActive { get; set; }

        public DateTime? createdAt { get; set; }
        [MaxLength(120)]
        public string createdBy { get; set; }

        public DateTime? updatedAt { get; set; }
        [MaxLength(120)]
        public string updatedBy { get; set; }
        [NotMapped]
        public string Token { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
