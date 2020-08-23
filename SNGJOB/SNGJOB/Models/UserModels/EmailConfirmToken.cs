using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNGJOB.Models.UserModels
{
    public class EmailConfirmToken
    {
        public int id { get; set; }
        [Key]
        [Column("ud_id")]
        public Guid user_id;
        [ForeignKey("ud_id")]
        public User user { get; set; }

        public string token { get; set; }


    }
}
