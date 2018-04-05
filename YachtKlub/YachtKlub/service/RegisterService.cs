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
    class RegisterService : ServiceResponse
    {
        private string city;
        private string country;
        private string email;
        private string firstname;
        private string houseNumber;
        private string lastname;
        private string password;
        private int permission;
        private string street;
        DatabaseContext dbc;

        public RegisterService(string firstname, string lastname, string email, string password, string country, string city, string street, string houseNumber)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.password = password;
            this.country = country;
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;

            dbc = AliveContext.Context;

            TryToRegister();
        }

        public RegisterService(string firstname, string lastname, string email, string password, string country, string city, string street, string houseNumber, int permission)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.password = password;
            this.country = country;
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
            this.permission = permission;

            dbc = AliveContext.Context;

            TryToRegisterWithPermission();
        }

        private void TryToRegisterWithPermission()
        {
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity memberAlreadyInDatabase = membersDao.getMemberByEmail(email);

            if (memberAlreadyInDatabase != null)
            {
                FeedbackMessage = "Ezzel az e-mail címmel már regisztrált valaki!";
                ServiceStatus = Status.Error;
            }
            else
            {
                MembersEntity newMemberEntity = new MembersEntity();

                newMemberEntity.MemberName = firstname + " " + lastname;
                newMemberEntity.Email = email;
                newMemberEntity.Password = password;
                newMemberEntity.Country = country;
                newMemberEntity.City = city;
                newMemberEntity.Street = street;
                newMemberEntity.HouseNumber = houseNumber;
                newMemberEntity.Permission = permission;

                //DatabaseContext dbc = new DatabaseContext();
                dbc.Members.Add(newMemberEntity);
                dbc.SaveChanges();

                FeedbackMessage = "Sikeres regisztráció!";
                ServiceStatus = Status.OK;
            }

            // it must be a method
            if (!string.IsNullOrEmpty(FeedbackMessage) && !string.IsNullOrWhiteSpace(FeedbackMessage))
            {
                new PrintMessageBox(FeedbackMessage, ServiceStatus);
            }
        }

        private void TryToRegister()
        {
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity memberAlreadyInDatabase = membersDao.getMemberByEmail(email);

            if (memberAlreadyInDatabase != null)
            {
                FeedbackMessage = "Ezzel az e-mail címmel már regisztrált valaki!";
                ServiceStatus = Status.Error;
            }
            else
            {
                MembersEntity newMemberEntity = new MembersEntity();

                newMemberEntity.MemberName = firstname + " " + lastname;
                newMemberEntity.Email = email;
                newMemberEntity.Password = password;
                newMemberEntity.Country = country;
                newMemberEntity.City = city;
                newMemberEntity.Street = street;
                newMemberEntity.HouseNumber = houseNumber;
                newMemberEntity.Permission = 1; // not admin

                dbc.Members.Add(newMemberEntity);
                dbc.SaveChanges();

                FeedbackMessage = "Sikeres regisztráció!";
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
