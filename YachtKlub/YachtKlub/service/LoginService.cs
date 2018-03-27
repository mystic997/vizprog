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
    class LoginService
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginService(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public ServiceResponse TryToLogin()
        {
            ServiceResponse response = new ServiceResponse();
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity member = membersDao.getMemberByEmail(Email);

            if (member == null || !member.Password.Equals(Password))
            {
                response.FeedbackMessage = "Hibás e-mail cím vagy jelszó!";
                response.ServiceStatus = Status.Error;
            }
            else
            {
                response.FeedbackMessage = "Sikeres belépés!";
                response.ServiceStatus = Status.OK;

                if (member.Permission == 0)
                {
                    response.ResponseMessage = "Admin";
                }
                else
                {
                    response.ResponseMessage = "User";
                }
            }

            // it must be a method
            if (!string.IsNullOrEmpty(response.FeedbackMessage) && !string.IsNullOrWhiteSpace(response.FeedbackMessage))
            {
                new PrintMessageBox(response.FeedbackMessage, response.ServiceStatus);
            }

            return response;
        }
    }
}
