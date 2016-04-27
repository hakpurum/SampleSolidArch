using Sample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Sample.Mvc.Models
{
    public class UserViewModel : User
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public override string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Surname cannot be longer than 50 characters.")]
        public override string LastName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Email cannot be longer than 150 characters.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public override string Email { get; set; }
    }
}