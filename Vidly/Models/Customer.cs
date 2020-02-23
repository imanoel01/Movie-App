using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [MaxLength(15)]
        [Display(Name = "MiddleName")]

        public string MiddleName { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "Last Name")]
        
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                string fullName = string.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
                return fullName;
            }
        }

        public bool IsSubscribedToNewsLetter { get; set; }
        [Display(Name ="Membership Type")]
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]

        public DateTime? DOB { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Gender")]
        public byte GenderId { get; set; }

    }
}