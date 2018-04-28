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
            var linqQuery = from row in dbc.RentRequests where row.BoatToBorrow.BoatId.Equals(BoatToBorrow.BoatId) select row;
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
            Random random = new Random();
            List<RentRequestsEntity> TemplateRequests = new List<RentRequestsEntity>();

            for (int i = 0; i < 20; i++)
            {
                RentRequestsEntity req = new RentRequestsEntity();

                MembersDao mem = new MembersDaoImpl();
                List<MembersEntity> mems = mem.GetAllMembers();
                req.WhoBorrows = mems[random.Next(0, mems.Count)];

                BoatsDao boat = new BoatsDaoImpl();
                List<BoatsEntity> boats = boat.GetAllBoats();
                req.BoatToBorrow = boats[random.Next(0, boats.Count)];

                TransportDevicesDao dev = new TransportDevicesDaoImpl();
                List<TransportDevicesEntity> devs = dev.GetAllTransportDevices();
                req.DeviceToBorrow = devs[random.Next(0, devs.Count)]; // ez null is lehet

                req.EndDate = new DateTime(random.Next(2018, 2020), random.Next(1, 13), random.Next(1, 29));
                req.StartingDate = new DateTime(2018, random.Next(1, 13), random.Next(1, 29));
                req.FromWhere = "Innen";
                req.ToWhere = "Ide";
                req.Status = 3; // 1 - elfogadva, 2 - elutasitva, 3 - kerve/varakozas valaszra
                req.HowManyPersonWillTravel = 5;

                TemplateRequests.Add(req);
            }

            return TemplateRequests;
        }
    }
}
