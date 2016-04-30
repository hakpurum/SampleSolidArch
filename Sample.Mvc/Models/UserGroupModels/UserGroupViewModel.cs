using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sample.Entities.Concrete;

namespace Sample.Mvc.Models
{
    public class UserGroupViewModel : UserGroup
    {
        [Required]
        [StringLength(100, ErrorMessage = "GroupName cannot be longer than 50 characters.")]
        public override string GroupName { get; set; }
    }
}