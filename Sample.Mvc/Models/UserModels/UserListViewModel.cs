using Sample.Entities.Concrete;
using System.Collections.Generic;

namespace Sample.Mvc.Models
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }

    }
}