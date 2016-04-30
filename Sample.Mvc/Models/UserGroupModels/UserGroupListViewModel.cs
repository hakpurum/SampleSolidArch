using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Entities.Concrete;

namespace Sample.Mvc.Models
{
    public class UserGroupListViewModel
    {
        public IEnumerable<UserGroup> UserGroups { get; set; }

    }
}