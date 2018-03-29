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
        public List<BoatsEntity> GetAllBoats()
        {
            //Random random = new Random();
            //List<BoatsEntity> TemplateBoatRentals = new List<BoatsEntity>();
            //BoatsEntity templateBoat = new BoatsEntity();
            //MembersDao membersDao = new MembersDaoImpl();
            //BoatRentalsDao boatRentalsDao = new BoatRentalsDaoImpl();
            //for (int i = 0; i < 15; i++)
            //{
            //    templateBoat.BoatId = i;
            //    templateBoat.BoatName = "BoatName" + i;
            //    templateBoat.BoatType = "BoatType" + (i%3);
            //    templateBoat.DailyPrice = random.Next(1, 15) * 100;
            //    templateBoat.FKOwner = membersDao.getMemberByEmail("user" + random.Next(0, 10) + "@gmail.com");
            //    templateBoat.IsLoan = "true";
            //    templateBoat.MaxPerson = random.Next(5, 25);
            //    templateBoat.MaxSpeed = random.Next(20, 70);
            //    templateBoat.DiveDepth = random.Next(60, 300);
            //    templateBoat.Consumption = random.Next(0, 15);
            //    templateBoat.YearOfManufacture = new DateTime(1995, 1, 1);
            //    templateBoat.BoatLength = random.Next(250, 2500);
            //    templateBoat.BoatWidth = random.Next(100, 1500);
            //    templateBoat.BoatImage = "BoatImage" + i;
            //    templateBoat.BoatRentals = 
            //}
            throw new NotImplementedException();
            /*Ez még nincs kész*/
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
