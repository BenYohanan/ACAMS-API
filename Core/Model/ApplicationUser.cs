using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberPassword { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public int? GenderId { get; set; }
        [Display(Name = "Gender")]
        [ForeignKey("GenderId")]
        public virtual CommonDropdowns Gender { get; set; }

        public int? StateId { get; set; }
        [ForeignKey("StateId")]
        [Display(Name = "State Of Origin")]
        public virtual State State { get; set; }

        public int? SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public virtual CommonDropdowns School { get; set; }

        public int? ReligionId { get; set; }
        [ForeignKey("ReligionId")]
        public virtual CommonDropdowns Religion { get; set; }

        public int? NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        public virtual Country Nationality { get; set; }

        public string Department { get; set; }

        public DateTime DateRegistered { get; set; }

        public bool Deactivated { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must be the same. ")]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public string FullName => FirstName + MiddleName + LastName;

    }
}
