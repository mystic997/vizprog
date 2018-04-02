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
        DatabaseContext dbc;

        public BoatRentalsDaoImpl()
        {
            dbc = new DatabaseContext();
        }

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

        public BoatRentalsEntity GetBoatRentalsById()
        {
            throw new NotImplementedException();
        }

        public List<BoatRentalsEntity> GetTemplateBoatRents()
        {
            //Random random = new Random();


            //List<BoatRentalsEntity> TemplateBoatRentalsEntity = new List<BoatRentalsEntity>();

            //for (int i = 0; i < 12; i++)
            //{

            //BoatRentalsEntity TemplateBoatRental = new BoatRentalsEntity();

            //TemplateBoatRental.StartingDate = new DateTime(2017,3,1+i);

            //TemplateBoatRental.FKRentedBoat = 

            //}
            throw new NotImplementedException();

        }
    }
}
