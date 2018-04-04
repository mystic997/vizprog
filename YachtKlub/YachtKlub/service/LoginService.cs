using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.dao;
using YachtKlub.entity;
using YachtKlub.validator;

namespace YachtKlub.service
{
    class LoginService : ServiceResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginService(string email, string password)
        {
            Email = email;
            Password = password;

            TryToLogin();
        }

        private void TryToLogin()
        {
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity member = membersDao.getMemberByEmail(Email);

            if (member == null || !member.Password.Equals(Password))
            {
                FeedbackMessage = "Hibás e-mail cím vagy jelszó!";
                ServiceStatus = Status.Error;
            }
            else
            {
                if (member.Permission == 0)
                {
                    ResponseMessage.Add("permission", "admin");
                }
                else
                {
                    ResponseMessage.Add("permission", "user");
                }

                FeedbackMessage = "Sikeres belépés!";
                ServiceStatus = Status.OK;
            }

            // it must be a method
            if (!string.IsNullOrEmpty(FeedbackMessage) && !string.IsNullOrWhiteSpace(FeedbackMessage))
            {
                new PrintMessageBox(FeedbackMessage, ServiceStatus);
            }
        }
    }
}
