using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    class MembersDaoImpl : MembersDao
    {
        private DatabaseContext databaseContext;
        private List<MembersEntity> MembersList;

        public MembersDaoImpl(DatabaseContext dbContext)
        {
            databaseContext = dbContext;
            MembersList = new List<MembersEntity>();
        }

        public List<MembersEntity> GetTemplateMembers()
        {
            List<MembersEntity> templateMembers = new List<MembersEntity>();

            for (int i = 0; i < 10; i++)
            {
                MembersEntity templateMember = new MembersEntity();
                templateMember.MemberId = i;
                templateMember.Email = "user" + i + "@gmail.com";
                templateMember.MemberName = "user" + i;
                templateMember.MemberImage = "userImage" + i;
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

        public List<MembersEntity> getAllMembers()
        {
            var linqQuery = from row in databaseContext.Members select row;
            MembersList = linqQuery.ToList<MembersEntity>();

            return MembersList;
        }

        public MembersEntity getMemberByEmail()
        {
            throw new NotImplementedException();
        }

        public MembersEntity getMemberById()
        {
            throw new NotImplementedException();
        }
    }
}
