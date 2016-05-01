
using Sample.Core.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Entities.Concrete
{
    public partial class Setting : IEntity
    {
        [Key]
        public int SettingId { get; set; }
        public virtual string SettingName { get; set; }

    }

}
