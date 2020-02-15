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
        public string FirstName { get; set; }
        [MaxLength(15)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(15)]
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
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        public DateTime? DOB { get; set; }
    }
}