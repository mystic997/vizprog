using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    interface MembersDao
    {
        MembersEntity getMemberById();
        MembersEntity getMemberByEmail(string email);
        List<MembersEntity> GetAllMembers();
        List<MembersEntity> GetTemplateMembers();

    }
}
