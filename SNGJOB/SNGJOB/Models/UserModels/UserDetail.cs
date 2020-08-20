using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SNGJOB.Models.UserModels
{
    public class UserDetail
    {
        public int id { get; set; }
        [Key]
        [Column("ud_id")]
        public Guid user_id;
        [ForeignKey("ud_id")]
        public User user { get; set; }
        [Column("ud_first_name")]
        public string firstName { get; set; }
        [Column("ud_last_name")]
        public string lastName { get; set; }
        [Column("ud_middle_name")]
        public string middleName { get; set; }
        [Column("ud_full_name")]
        public string fullName { get; set; }
        [Column("ud_address")]
        public string address { get; set; }
        [Column("ud_emails")]
        public string emails { get; set; }
        [Column("ud_date_of_birth")]
        public string DateOfBirth { get; set; }
        [Column("ud_interests")]
        public Byte interests { get; set; }
        [Column("ud_photos")]
        public string photos { get; set; }
        [Column("ud_country")]
        public string country { get; set; }
        [Column("ud_city")]
        public string city { get; set; }
        [Column("ud_state")]
        public string state { get; set; }
    }
}
