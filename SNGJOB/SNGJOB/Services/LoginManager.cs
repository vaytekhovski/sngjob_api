using Microsoft.Extensions.Configuration;
using SNGJOB.Models.UserModels;
using System;
using System.Linq;

namespace SNGJOB.Services
{
    public class LoginManager
    {
        private IConfiguration configuration;

        private Security Security;
        public LoginManager(IConfiguration configuration, Security security)
        {
            this.configuration = configuration;

            Security = security;
        }
        public User AuthenticateUser(User login)
        {
            User user = null;

            using (DatabaseContext db = new DatabaseContext())
            {
                user = db.users
                    .Where(x => x.email == login.email)
                    .Where(x => x.password == Security.Hash(login.password))
                    .FirstOrDefault();
            }

            return user;
        }

        public User CreateUser(User login)
        {
            User user = new User
            {
                email = login.email,
                password = Security.Hash(login.password),
                creationDate = DateTime.Now,
            };

            UserDetail userDetail = new UserDetail
            {
                fullName = user.email,
                user = user
            };

            using (DatabaseContext db = new DatabaseContext())
            {
                var exist_user = db.users.FirstOrDefault(x => x.email == user.email);
                if (exist_user == null)
                {
                    db.users.Add(user);
                    db.user_details.Add(userDetail);
                    db.SaveChanges();
                }
                else
                {
                    user = null;
                }
            }
            return user;
        }

        public string GetJSONWebToken(User user)
        {
            UserDetail userDetail;
            using(DatabaseContext db = new DatabaseContext())
            {
                userDetail = db.user_details.FirstOrDefault(x => x.user.id == user.id);
                userDetail.user = db.users.FirstOrDefault(x => x.id == user.id);
            }
            return Security.GenerateJSONWebToken(userDetail, configuration);
        }
    }
}
