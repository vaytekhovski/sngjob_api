using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SNGJOB.Models.UserModels
{
    public class UserEmployment
    {
        public int id { get; set; }

        [Key]
        [Column("uet_user_id")]
        public Guid user_id;
        [ForeignKey("uet_user_id")]
        public User user { get; set; }
        [Column("uet_name")]
        public string name { get; set; }
        [Column("uet_area")]
        public string area { get; set; }
        [Column("uet_address")]
        public string address { get; set; }
        [Column("uet_phone")]
        public string phone { get; set; }
    }
}
