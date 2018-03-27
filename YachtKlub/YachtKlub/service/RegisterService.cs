﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.dao;
using YachtKlub.entity;
using YachtKlub.validator;

namespace YachtKlub.service
{
    class RegisterService
    {
        private string city;
        private string country;
        private string email;
        private string firstname;
        private string houseNumber;
        private string lastname;
        private string password;
        private string street;

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
        }

        internal ServiceResponse TryToRegister()
        {
            ServiceResponse response = new ServiceResponse();
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity memberAlreadyInDatabase = membersDao.getMemberByEmail(email);

            if (memberAlreadyInDatabase != null)
            {
                response.FeedbackMessage = "Ezzel az e-mail címmel már regisztrált valaki!";
                response.ServiceStatus = Status.Error;
            }
            else
            {
                MembersEntity newMemberEntity = new MembersEntity();

                newMemberEntity.MemberName = firstname + " " + lastname;
                newMemberEntity.Email = email;
                newMemberEntity.Password = password;
                // country hianyzik
                newMemberEntity.City = city;
                newMemberEntity.Street = street;
                newMemberEntity.HouseNumber = houseNumber;
                newMemberEntity.Permission = 1; // not admin

                DatabaseContext dbc = new DatabaseContext();
                dbc.Members.Add(newMemberEntity);
                dbc.SaveChanges();

                response.FeedbackMessage = "Sikeres regisztráció!";
                response.ServiceStatus = Status.OK;
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