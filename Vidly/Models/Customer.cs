using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
      [StringLength(255)]

      [Required(ErrorMessage = "Please enter Customer Name")]
        public string Name { get; set; }

        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribeToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }


        public bool IsDeleted { get; set; }

        public string ImageUrl { get; set; }
        public byte[] Image { get; set; }

       

    }
}