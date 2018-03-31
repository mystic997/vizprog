using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    class BoatsDaoImpl : BaseDao<BoatsEntity>, BoatsDao
    {
        DatabaseContext dbc;

        public BoatsDaoImpl()
        {
            dbc = new DatabaseContext();
        }

        public List<BoatsEntity> GetAllBoats()
        {
            var linqQuery = from row in dbc.Boats select row;
            List<BoatsEntity> BoatsList = linqQuery.ToList();
            return BoatsList;
        }
        public List<BoatsEntity> GetAllBoatsByOwner(MembersEntity Owner)/*Függvény, ami visszaad egy listát, ami tartalmazza, az adott felhasználó hajóit*/
        {
            var linqQuery = from row in dbc.Boats where row.FKOwner.Equals(Owner) select row;
            List<BoatsEntity> BoatsList = linqQuery.ToList();
            return BoatsList;
        }

        public BoatsEntity GetBoatsById()
        {
            throw new NotImplementedException();
        }

        public List<BoatsEntity> GetTemplateBoats()
        {
            throw new NotImplementedException();
        }
    }
}
