using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    class RentRequestsDaoImpl : BaseDao<RentRequestsEntity>, RentRequestsDao
    {
        DatabaseContext dbc;

        public RentRequestsDaoImpl()
        {
            dbc = new DatabaseContext();
        }

        public List<RentRequestsEntity> GetAllRentRequests()
        {
            var linqQuery = from row in dbc.RentRequests select row;
            List<RentRequestsEntity> RentRequestsList = linqQuery.ToList();
            return RentRequestsList;
        }

        public List<RentRequestsEntity> GetAllRentRequestsByWhoBorrows(MembersEntity WhoBorrows)/*Függvény, ami visszaad egy listát, ami tartalmazza, hogy az adott felhasználónak, milyen kölcsönzési kérelmei vannak vannak*/
        {
            var linqQuery = from row in dbc.RentRequests where row.WhoBorrows.Equals(WhoBorrows) select row;
            List<RentRequestsEntity> RentRequestsList = linqQuery.ToList();
            return RentRequestsList;
        }

        public List<RentRequestsEntity> GetAllRentRequestsByBoatToBorrow(BoatsEntity BoatToBorrow)/*Függvény, ami visszaad egy listát, ami tartalmazza, hogy az adott hajónak, milyen kölcsönzési kérelmei vannak vannak*/
        {
            var linqQuery = from row in dbc.RentRequests where row.BoatToBorrow.Equals(BoatToBorrow) select row;
            List<RentRequestsEntity> RentRequestsList = linqQuery.ToList();
            return RentRequestsList;
        }

        public List<RentRequestsEntity> GetAllRentRequestsByTransportDeviceToBorrow(BoatsEntity DeviceToBorrow)/*Függvény, ami visszaad egy listát, ami tartalmazza, hogy az adott hajónak, milyen kölcsönzési kérelmei vannak vannak*/
        {
            var linqQuery = from row in dbc.RentRequests where row.DeviceToBorrow.Equals(DeviceToBorrow) select row;
            List<RentRequestsEntity> RentRequestsList = linqQuery.ToList();
            return RentRequestsList;
        }

        public RentRequestsEntity GetRentRequestsById()
        {
            throw new NotImplementedException();
        }

        public List<RentRequestsEntity> GetTemplateRentRequests()
        {
            List<RentRequestsEntity> TemplateRequests = new List<RentRequestsEntity>();

            for (int i = 0; i < 10; i++)
            {
                RentRequestsEntity req = new RentRequestsEntity();

                MembersDao membersDao = new MembersDaoImpl();
                MembersEntity member = membersDao.getMemberByEmail("user1gmail.com");
                BoatsDao boat = new BoatsDaoImpl();

                req.BoatToBorrow = boat.GetBoatsById(0);
                req.DeviceToBorrow = new TransportDevicesEntity(); // ez null is lehet akar
                req.WhoBorrows = member;

                req.EndDate = new DateTime();
                req.StartingDate = new DateTime();
                req.FromWhere = "Innen";
                req.ToWhere = "Ide";
                req.HowManyPersonWillTravel = 5;
            }

            return TemplateRequests;
        }
    }
}
