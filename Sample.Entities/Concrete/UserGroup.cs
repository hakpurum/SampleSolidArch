using Sample.Core.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Entities.Concrete
{
    public partial class UserGroup : IEntity
    {
        [Key]
        public int UserGroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
