
using Sample.Core.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Entities.Concrete
{
    public partial class Category : IEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }

    }

}
