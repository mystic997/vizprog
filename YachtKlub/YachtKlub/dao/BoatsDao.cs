using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    interface BoatsDao
    {
        BoatsEntity GetBoatsById(int id);
        List<BoatsEntity> GetAllBoatsByOwner(MembersEntity Owner);
        List<BoatsEntity> GetAllBoats();
        List<BoatsEntity> GetTemplateBoats();
        List<BoatsEntity> GetBookableBoats(DateTime startingDate, DateTime endingDate);
    }
}
