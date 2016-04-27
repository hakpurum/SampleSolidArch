using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entities.Concrete
{
    class PartialClass
    {
    }

    public partial class User
    {
        public IEnumerable<UserGroup> UserGroups { get; set; }
    }
    
}
