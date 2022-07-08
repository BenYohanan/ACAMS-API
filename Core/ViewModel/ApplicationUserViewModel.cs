using Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "FullName")]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmEmail { get; set; }

        [Display(Name = "Remember My Password")]
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
        [Display(Name = "School")]
        public virtual CommonDropdowns School { get; set; }

        public int? ReligionId { get; set; }
        [ForeignKey("ReligionId")]
        [Display(Name = "Religion")]
        public virtual CommonDropdowns Religion { get; set; }

        [Display(Name = "School Address")]
        public string SchoolAddress { get; set; }

        public int? NationalityId { get; set; }
        [Display(Name = "Nationality")]
        [ForeignKey("NationalityId")]
        public virtual Country Nationality { get; set; }

        [Display(Name = "Department")]
        public string Department { get; set; }

        public string Layout { get; set; }
        public DateTime DateRegistered { get; set; }
        public bool Deactivated { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must be the same. ")]
        public string ConfirmPassword { get; set; }

    }
}
