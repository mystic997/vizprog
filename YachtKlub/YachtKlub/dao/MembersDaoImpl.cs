using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    class MembersDaoImpl : BaseDao<MembersEntity>, MembersDao
    {
        public List<MembersEntity> GetTemplateMembers()
        {
            List<MembersEntity> templateMembers = new List<MembersEntity>();

            for (int i = 0; i < 10; i++)
            {
                MembersEntity templateMember = new MembersEntity();
                templateMember.MemberId = i;
                templateMember.Email = "user" + i + "@gmail.com";
                templateMember.MemberName = "user" + i;

                templateMember.MemberImage =System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "resources" + "\\" + "stock_avatar.png";
                templateMember.Country = "Hungary";
                templateMember.City = "userCity" + i;
                templateMember.Street = "userStreet" + i;
                templateMember.HouseNumber = "userHouseNumber" + i;
                templateMember.Password = "user" + i;

                if (i % 2 == 0)
                    templateMember.Permission = 0;
                else
                    templateMember.Permission = 1;

                templateMembers.Add(templateMember);
            }

            return templateMembers;
        }

        public List<MembersEntity> GetAllMembers()
        {
            var linqQuery = from row in dbc.Members select row;

            List<MembersEntity> membersList = linqQuery.ToList();

            return membersList;
        }

        public MembersEntity getMemberByEmail(string email)
        {
            var linqQuery = from row in dbc.Members
                            where row.Email.Equals(email)
                            select row;

            List<MembersEntity> membersList = linqQuery.ToList();
            MembersEntity member = GetSingleResultWithoutExc(membersList);

            return member;
        }

        public MembersEntity getMemberByBoat(BoatsEntity boat)
        {
            var linqQuery = from row in dbc.Members
                            where row.Email.Equals(boat.FKOwner.Email)
                            select row;

            List<MembersEntity> membersList = linqQuery.ToList();
            MembersEntity member = GetSingleResultWithoutExc(membersList);

            return member;
        }

        public MembersEntity getMemberById()
        {
            throw new NotImplementedException();
        }
    }
}
