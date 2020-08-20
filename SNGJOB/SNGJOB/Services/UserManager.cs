using Microsoft.Extensions.Configuration;
using SNGJOB.Models.UserModels;
using System;
using System.Linq;

namespace SNGJOB.Services
{
    public class UserManager
    {
        private IConfiguration Configuration;
        private Security Security;

        public UserManager(IConfiguration configuration, Security security)
        {
            Configuration = configuration;
            Security = security;
        }

        public string ChangeUserData(Guid UserId, UserDetail UserDetail)
        {
            string status = "200";
            using(DatabaseContext db = new DatabaseContext())
            {
                var User = db.user_details.FirstOrDefault(x => x.user.id == UserId);
                if(User != null)
                {
                    if(UserDetail.firstName != null)
                    {
                        User.firstName = UserDetail.firstName;
                    }

                    if(UserDetail.lastName != null)
                    {
                        User.lastName = UserDetail.lastName;
                    }

                    if(UserDetail.middleName != null)
                    {
                        User.middleName = UserDetail.middleName;
                    }

                    User.fullName = User.firstName + " " + User.middleName + " " + User.lastName;

                    if(UserDetail.address != null)
                    {
                        User.address = UserDetail.address;
                    }

                    if(UserDetail.DateOfBirth != null)
                    {
                        User.DateOfBirth = UserDetail.DateOfBirth;
                    }

                    if(UserDetail.country != null)
                    {
                        User.country = UserDetail.country;
                    }

                    if(UserDetail.city != null)
                    {
                        User.city = UserDetail.city;
                    }

                    if(UserDetail.state != null)
                    {
                        User.state = UserDetail.state;
                    }
                    db.SaveChanges();
                }
                else
                {
                    status = "404";
                }
            }

            return status;
        }

       



    }
}
