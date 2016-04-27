using Sample.Core.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Entities.Concrete
{
    public partial class User : IEntity
    {
        [Key]
        public int UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime CreatedDate { get; set; }

        [ForeignKey("UserGroup")]
        public int UserGroupId { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
