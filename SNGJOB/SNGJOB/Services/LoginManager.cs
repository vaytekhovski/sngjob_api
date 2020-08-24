using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SNGJOB.Models.UserModels;
using System;
using System.Linq;

namespace SNGJOB.Services
{
    public class LoginManager
    {
        private IConfiguration configuration;

        private Security security;

        private readonly MailManager mailManager;
        public LoginManager(IConfiguration configuration, Security security, MailManager mailManager)
        {
            this.configuration = configuration;
            this.mailManager = mailManager;
            this.security = security;
        }
        public User AuthenticateUser(User login)
        {
            User user = null;

            using (DatabaseContext db = new DatabaseContext())
            {
                user = db.users
                    .Where(x => x.email == login.email)
                    .Where(x => x.password == security.Hash(login.password))
                    .FirstOrDefault();
            }

            return user;
        }

        public User CreateUser(User login)
        {
            User user = new User
            {
                email = login.email,
                password = security.Hash(login.password),
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
                    EmailConfirm(user.email);

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
            return security.GenerateJSONWebToken(userDetail, configuration);
        }

        

        public string RecoverPassword(string email)
        {
            string passwordToken = "404";
            using(DatabaseContext db = new DatabaseContext())
            {
                var user = db.users.FirstOrDefault(x => x.email == email);
                if (user != null)
                {
                    passwordToken = security.GenerateRandomKey(6);
                    user.passwordToken = passwordToken;
                    db.SaveChanges();
                    mailManager.SendEmailDefaul(email, "Восстановление пароля", passwordToken);
                }
            }
            return passwordToken;
        }

        public string GetRecoverToken(string email)
        {
            string passwordToken = "404";
            using(DatabaseContext db = new DatabaseContext())
            {
                var user = db.users.AsNoTracking().FirstOrDefault(x => x.email == email);
                if (user != null)
                {
                    passwordToken = user.passwordToken;
                }
            }
            return passwordToken;
        }


        public string EmailConfirm(string email)
        {
            string emailToken = "404";

            using (DatabaseContext db = new DatabaseContext())
            {
                var user = db.users.FirstOrDefault(x => x.email == email);
                if (user != null)
                {
                    emailToken = security.GenerateRandomKey(6);
                    user.emailToken = emailToken;
                    db.SaveChanges();
                    mailManager.SendEmailDefaul(email, "Подтверждение почты", emailToken);
                }
            }


            return emailToken;
        }

        public string GetVerifyToken(string email)
        {
            string emailToken = "404";
            using(DatabaseContext db = new DatabaseContext())
            {
                var user = db.users.AsNoTracking().FirstOrDefault(x => x.email == email);
                if (user != null)
                {
                    emailToken = user.emailToken;
                }
            }

            return emailToken;
        }

        public string DeleteUser(Guid userId)
        {
            string response = "404";
            using(DatabaseContext db = new DatabaseContext())
            {
                var user = db.users.FirstOrDefault(x => x.id == userId);
                if(user != null)
                {
                    db.users.Remove(user);
                    db.SaveChanges();
                    response = "ok"; 
                }
            }

            return response;
        }

    }
}
