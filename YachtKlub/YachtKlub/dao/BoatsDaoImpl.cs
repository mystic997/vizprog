using System;
using System.Collections.Generic;
using System.Linq;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    class BoatsDaoImpl : BaseDao<BoatsEntity>, BoatsDao
    {
        public List<BoatsEntity> GetAllBoats()
        {
            var linqQuery = from row in dbc.Boats select row;
            List<BoatsEntity> BoatsList = linqQuery.ToList();
            return BoatsList;
        }

        public List<BoatsEntity> GetAllBoatsByOwner(MembersEntity Owner)/*Függvény, ami visszaad egy listát, ami tartalmazza, az adott felhasználó hajóit*/
        {
            var linqQuery = from row in dbc.Boats where row.FKOwner.MemberId.Equals(Owner.MemberId) select row;
            List<BoatsEntity> BoatsList = linqQuery.ToList();
            return BoatsList;
        }

        public BoatsEntity GetBoatsById(int id)
        {
            var linqQuery = from row in dbc.Boats where row.BoatId == id select row;
            List<BoatsEntity> BoatsList = linqQuery.ToList();

            return GetSingleResultWithoutExc(BoatsList);
        }

        public List<BoatsEntity> GetBookableBoats(DateTime startingDate, DateTime endingDate)
        {
            var linqQuery = from boat in dbc.Boats
                            join rental in dbc.BoatRentals on boat.BoatId equals rental.FKRentedBoat.BoatId
                            where boat.IsLoan == true && !(
                                    startingDate < rental.EndDate &&
                                    endingDate > rental.StartingDate
                            )
                            select rental.FKRentedBoat;

            var linqQuery2 = from boat in dbc.Boats
                             where boat.IsLoan == true &&
                             !(from rent in dbc.BoatRentals
                               select rent.FKRentedBoat.BoatId).Contains(boat.BoatId)
                             select boat;

            var list1 = linqQuery.ToList().Distinct().ToList();
            var list2 = linqQuery2.ToList().Distinct().ToList();
            var union = list1.Union(list2).ToList();

            return union;
        }

        public List<BoatsEntity> GetTemplateBoats()
        {
            Random random = new Random();
            List<BoatsEntity> TemplateBoats = new List<BoatsEntity>();

            for (int i = 0; i < 35; i++)
            {
                BoatsEntity TemplateBoat = new BoatsEntity();

                TemplateBoat.BoatId = i;
                TemplateBoat.BoatName = "BoatName" + i;
                TemplateBoat.BoatType = "BoatType" + random.Next(0, 4);
                TemplateBoat.DailyPrice = random.Next(15000, 25000);
                TemplateBoat.WhereIsNowTheBoat = "Place" + random.Next(0, 7);
                TemplateBoat.IsLoan = true;
                TemplateBoat.MaxPerson = random.Next(1, 15);
                TemplateBoat.MaxSpeed = random.Next(5, 50);
                TemplateBoat.DiveDepth = random.Next(100, 300) / 100;
                TemplateBoat.Consumption = random.Next(100, 500) / 100;
                TemplateBoat.YearOfManufacture = random.Next(1980, 2019);
                TemplateBoat.BoatLength = random.Next(150, 700) / 100;
                TemplateBoat.BoatWidth = random.Next(150, 400) / 100;
                TemplateBoat.BoatImage = "Stock_boat_image.png";
                TemplateBoat.WhereIsNowTheBoat = "Itt";

                // FK's
                MembersDao mem = new MembersDaoImpl();
                List<MembersEntity> mems = mem.GetAllMembers();
                TemplateBoat.FKOwner = mems[random.Next(0, mems.Count)];
                TemplateBoat.BoatRentals = new List<BoatRentalsEntity>();
                TemplateBoat.RentRequests = new List<RentRequestsEntity>();

                TemplateBoats.Add(TemplateBoat);
            }

            return TemplateBoats;
        }
    }
}
