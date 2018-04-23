using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    class BoatRentalsDaoImpl : BaseDao<BoatRentalsEntity>, BoatRentalsDao
    {
        public List<BoatRentalsEntity> GetAllBoatRents()
        {
            var linqQuery = from row in dbc.BoatRentals select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList;
        }

        public List<BoatRentalsEntity> GetBoatRentalsByBoat(BoatsEntity RentedBoat)/*Függvény, ami visszaad egy listát, ami tartalmazza, hogy az adott hajóhoz milyen kölcsönzések vannak*/
        {
            var linqQuery = from row in dbc.BoatRentals where row.FKRentedBoat.Equals(RentedBoat) select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList;
        }

        public List<BoatRentalsEntity> GetBoatRentalsByWhoRents(MembersEntity WhoRents)/*Függvény, ami visszaad egy listát, ami tartalmazza, hogy az adott felhaszálónak milyen kölcsönzései vannak*/
        {
            var linqQuery = from row in dbc.BoatRentals where row.FKWhoRents.Equals(WhoRents) select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList;
        }
        public int GetHowManyBoatRentalsByMonthAndBoat(int numberOfMonth,int id)
        {
            var linqQuery = from row in dbc.BoatRentals where (row.StartingDate.Month.Equals(numberOfMonth) & row.FKRentedBoat.BoatId.Equals(id) )select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList.Count;
        }
        public BoatRentalsEntity GetBoatRentalsById()
        {
            throw new NotImplementedException();
        }

        public List<BoatRentalsEntity> GetTemplateBoatRents()
        {
            Random random = new Random();
            List<BoatRentalsEntity> TemplateBoatRentals = new List<BoatRentalsEntity>();
            int a = 500;
            for (int i = 0; i < a; i++)
            {
                BoatRentalsEntity TemplateBoatRental = new BoatRentalsEntity();
                TemplateBoatRental.BoatRentalsId = generateID();
                TemplateBoatRental.FromWhere = "Innen";
                TemplateBoatRental.ToWhere = "Ide";
                TemplateBoatRental.HowManyPersonWillTravel = 4;

                // FK's
                MembersDao mem = new MembersDaoImpl();
                List<MembersEntity> mems = mem.GetAllMembers();
                TemplateBoatRental.FKWhoRents = mems[random.Next(0, mems.Count)];

                BoatsDao boat = new BoatsDaoImpl();
                List<BoatsEntity> boats = boat.GetAllBoats();
                TemplateBoatRental.FKRentedBoat = boats[random.Next(0, boats.Count)];

                TransportDevicesDao device = new TransportDevicesDaoImpl();
                List<TransportDevicesEntity> devices = device.GetAllTransportDevices();
                TemplateBoatRental.FKRentedDevice = devices[random.Next(0, devices.Count)];

                TemplateBoatRentals.Add(TemplateBoatRental);
            }
            for (int i = 0; i < a; i++)
            {
                int temp = random.Next(1, 12);
                TemplateBoatRentals[i].StartingDate = new DateTime(2018, temp, 4);
                TemplateBoatRentals[i].EndDate = new DateTime(2018, temp, 10);

            }



            return TemplateBoatRentals;
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
