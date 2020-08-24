using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace SNGJOB.Models.UserModels
{
    public class User
    {
        [Key]
        [Column("us_id")]
        public Guid id { get; set; }

        [Column("us_type")]
        public UsersType type { get; set; }

        [Column("us_email")]
        public string email { get; set; }
        [Column("us_email_token")]

        public string emailToken { get; set; }

        [Column("us_phone")]
        public string phone { get; set; }

        [Column("us_password")]
        public string password { get; set; }

        [Column("us_password_token")]
        public string passwordToken { get; set; }

        [Column("us_creation_date")]
        public DateTime creationDate { get; set; }

        [Column("us_update_date")]
        public DateTime updateDate { get; set; }

        [Column("us_delete_timeout")]
        public DateTime deleteTimeout { get; set; }
    }
}
