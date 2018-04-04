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
    class PasswordChangeService : ServiceResponse
    {
        DatabaseContext dbc;

        public string OldPassword { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }


        public PasswordChangeService(string oldPassword, string password, string email)
        {
            dbc = AliveContext.Context;
            OldPassword = oldPassword;
            Password = password;
            Email = email;

            TryToChangePassword();
        }

        private void TryToChangePassword()
        {
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity member = membersDao.getMemberByEmail(Email);

            if (!member.Password.Equals(OldPassword))
            {
                FeedbackMessage = "Hibásan adta meg a régi jelszót!";
                ServiceStatus = Status.Error;
            }
            else
            {
                member.Password = Password;
                dbc.SaveChanges();
                FeedbackMessage = "Sikeres jelszó változtatás!";
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
