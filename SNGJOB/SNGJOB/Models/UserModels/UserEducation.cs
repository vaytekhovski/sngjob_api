using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SNGJOB.Models.UserModels
{
    public class UserEducation
    {
        public int id { get; set; }

        [Key]
        [Column("ue_user_id")]
        public Guid user_id;
        [ForeignKey("ue_user_id")]
        public User user { get; set; }
        [Column("ue_name")]
        public string name { get; set; }
        [Column("ue_type")]
        public string type { get; set; }
        [Column("ue_address")]
        public string address { get; set; }
    }
}
