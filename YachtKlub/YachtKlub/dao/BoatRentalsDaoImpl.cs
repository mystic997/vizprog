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

            for (int i = 0; i < 50; i++)
            {
                BoatRentalsEntity TemplateBoatRental = new BoatRentalsEntity();

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

            TemplateBoatRentals[0].StartingDate = new DateTime(2018, 4, 4);
            TemplateBoatRentals[0].EndDate = new DateTime(2018, 4, 10);

            TemplateBoatRentals[1].StartingDate = new DateTime(2018, 3, 4);
            TemplateBoatRentals[1].EndDate = new DateTime(2018, 3, 10);

            TemplateBoatRentals[2].StartingDate = new DateTime(2018, 6, 4);
            TemplateBoatRentals[2].EndDate = new DateTime(2018, 6, 10);

            TemplateBoatRentals[3].StartingDate = new DateTime(2018, 4, 2);
            TemplateBoatRentals[3].EndDate = new DateTime(2018, 4, 6);

            TemplateBoatRentals[4].StartingDate = new DateTime(2018, 7, 4);
            TemplateBoatRentals[4].EndDate = new DateTime(2018, 8, 10);

            for (int i = 0; i < random.Next(1,11); i++)
            { int a = random.Next(1, 12);
                TemplateBoatRentals[4].StartingDate = new DateTime(2018, a, 4);
                TemplateBoatRentals[4].EndDate = new DateTime(2018, a+1, 10);
            }

            return TemplateBoatRentals;
        }
    }
}
