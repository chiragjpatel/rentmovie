using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDtos
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribeToNewsletter { get; set; }

        public int MembershipTypeId { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsDeleted { get; set; }

        public string ImageUrl { get; set; }


        //public MembershipTypeDtos MembershipType { get; set; }

    }
}