using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace QX_Frame.DAL.Service
{

    public partial class tb_User
    {
        [Key]
        public Guid Uid { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        public int ClassId { get; set; }
        //[JsonIgnore]
        public virtual tb_Class tb_Class { get; set; }
    }
}
