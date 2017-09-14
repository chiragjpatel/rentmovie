using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId==MembershipType.PayAsYouGo)

                    return ValidationResult.Success;

            if (customer.BirthDate == null)

                return new ValidationResult("Birthdate is required");


            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            if (age >=18)

                return ValidationResult.Success;
            return new ValidationResult("Age must be 18 or higher with selected Membership type");


        }
    }
}