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
            Random random = new Random();

            List<BoatsEntity> TemplateBoats = new List<BoatsEntity>();

            for (int i = 0; i < 12; i++)
            {

            BoatsEntity TemplateBoat = new BoatsEntity();

                TemplateBoat.BoatId = i;
                TemplateBoat.BoatName = "BoatName" + i;
                TemplateBoat.BoatType = "BoatType" + random.Next(0, 4);
                TemplateBoat.DailyPrice = random.Next(25000, 15000);

                MembersDao mem = new MembersDaoImpl();
                List<MembersEntity> mems = mem.GetTemplateMembers();

                TemplateBoat.FKOwner = mems[random.Next(0, mems.Count)];

                TemplateBoat.WhereIsNowTheBoat = "Place" + random.Next(0, 7);

                TemplateBoat.IsLoan = "true";

                TemplateBoat.MaxPerson = random.Next(1, 15);
                TemplateBoat.MaxSpeed = random.Next(5, 50);//knots
                TemplateBoat.DiveDepth = random.Next(100, 300) / 100;
                TemplateBoat.Consumption = random.Next(100, 500) / 100;
                TemplateBoat.YearOfManufacture = new DateTime(2018, 4, 2);
                TemplateBoat.BoatLength = random.Next(150, 700) / 100;
                TemplateBoat.BoatWidth = random.Next(150, 400) / 100;
                TemplateBoat.BoatImage = "BoatImage" + i;

                TemplateBoat.BoatRentals = new List<BoatRentalsEntity>();//Ez csak ideiglenes

                TemplateBoat.RentRequests = new List<RentRequestsEntity>();//Ez csak ideiglenes

                TemplateBoats.Add(TemplateBoat);
            }

            return TemplateBoats;

        }
    }
}
