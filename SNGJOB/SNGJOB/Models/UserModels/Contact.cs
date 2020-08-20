using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SNGJOB.Models.UserModels
{
    public class Contact
    {
        public int id { get; set; }

        [Key]
        [Column("cs_user_id")]
        public Guid user_id;
        [ForeignKey("cs_user_id")]
        public User user { get; set; }
        [Column("cs_contact_id")]
        public Guid contactId { get; set; }
        [Column("cs_name")]
        public string  name { get; set; }
    }
}
