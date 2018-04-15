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
    class UpdateUserDataService : ServiceResponse
    {
        private string city;
        private string country;
        private string email;
        private string firstname;
        private string houseNumber;
        private string lastname;
        private int permission;
        private string street;
        string picturePath;
        DatabaseContext dbc;

        public UpdateUserDataService(string firstname, string lastname, string email, string country, string city, string street, string houseNumber, int permission, string picturePath)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.country = country;
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
            this.permission = permission;
            this.picturePath = picturePath;
            dbc = AliveContext.Context;

            UpdateUser();
        }

        private void UpdateUser()
        {
            //DatabaseContext dbc = new DatabaseContext();
            MembersEntity memberData = dbc.Members.SingleOrDefault(m => m.Email.Equals(email));

            memberData.MemberName = firstname + " " + lastname;
            memberData.Email = email;
            memberData.Country = country;
            memberData.City = city;
            memberData.Street = street;
            memberData.HouseNumber = houseNumber;
            memberData.Permission = permission;
            memberData.MemberImage = picturePath;

            dbc.SaveChanges();

            FeedbackMessage = "Adatok sikeresen módosítva!";
            ServiceStatus = Status.OK;

            // it must be a method
            if (!string.IsNullOrEmpty(FeedbackMessage) && !string.IsNullOrWhiteSpace(FeedbackMessage))
            {
                new PrintMessageBox(FeedbackMessage, ServiceStatus);
            }
        }
    }
}
