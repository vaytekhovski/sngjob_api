using Microsoft.EntityFrameworkCore;
using SNGJOB.Models.ItemModels;
using SNGJOB.Models.TaskModels;
using SNGJOB.Models.UserModels;

namespace SNGJOB
{
    public class DatabaseContext : DbContext
    {

        public string ConnectionString { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=157.230.97.233;Port=6606;Database=sngjob;Uid=pro;Pwd=rsE>9S^2Fu:kNVc:;charset=utf8");
        }

        public DbSet<User> users { get; set; }
        public DbSet<UserDetail> user_details { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<UserEducation> user_educations { get; set; }
        public DbSet<Allie> allies { get; set; }
        public DbSet <UserEmployment> user_employments { get; set; }
        public DbSet<EmailConfirmToken> email_confirm_tokens { get; set; }
    }
}
