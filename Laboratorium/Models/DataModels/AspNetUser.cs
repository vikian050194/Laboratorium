using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium.Models.DataModels
{
    public class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetRoles = new HashSet<AspNetRole>();
            Scripts = new HashSet<Script>();
        }

        public string Id { get; set; }

        [MinLength(2)]
        [StringLength(256)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [StringLength(256)]
        public string LastName { get; set; }

        [MinLength(2)]
        [StringLength(256)]
        public string Patronymic { get; set; }

        [MinLength(4)]
        [StringLength(256)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }

        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }

        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }

        public virtual ICollection<Script> Scripts { get; set; }
    }
}
