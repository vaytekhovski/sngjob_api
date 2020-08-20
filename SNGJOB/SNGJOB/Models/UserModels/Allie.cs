using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SNGJOB.Models.UserModels
{
    public class Allie
    {
        public int id { get; set; }
        [Key]
        [Column("as_user_id")]
        public Guid user_id;
        [ForeignKey("as_user_id")]
        public User user { get; set; }

        [Column("as_allie_id")]
        public Guid allie_id;
        [ForeignKey("as_allie_id")]
        public User allie { get; set; }
    }
}
