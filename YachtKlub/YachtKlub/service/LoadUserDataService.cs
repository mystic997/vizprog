using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.dao;
using YachtKlub.entity;

namespace YachtKlub.service
{
    class LoadUserDataService : ServiceResponse
    {
        private string email;

        public LoadUserDataService(string email)
        {
            this.email = email;

            LoadUserData();
        }

        private void LoadUserData()
        {
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity member = membersDao.getMemberByEmail(email);

            ResponseMessage.Add("email", member.Email);
            ResponseMessage.Add("password", member.Password);
            ResponseMessage.Add("permission", member.Permission.ToString());

            char[] delimiter = { ' ' };
            string[] memberName = member.MemberName.Split(delimiter);
            string[] firstnameaArray = memberName.Take(memberName.Count() - 1).ToArray();
            string firstname = string.Join(" ", firstnameaArray);
            string lastname = memberName.Last();
            ResponseMessage.Add("firstname", firstname);
            ResponseMessage.Add("lastname", lastname);

            // TO DO: country
            ResponseMessage.Add("city", member.City);
            ResponseMessage.Add("street", member.Street);
            ResponseMessage.Add("houseNumber", member.HouseNumber);

            // TO DO: IMAGE
            //ResponseMessage.Add("email", member.MemberImage);
        }
    }
}
