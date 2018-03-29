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
            Random random = new Random();
            List<BoatRentalsEntity> TemplateBoatRentals = new List<BoatRentalsEntity>();

            BoatRentalsEntity templateBoatRental = new BoatRentalsEntity();

            MembersDao membersDao = new MembersDaoImpl();
            templateBoatRental.FKWhoRents = membersDao.getMemberByEmail("user" + random.Next(0, 10) + "@gmail.com");
            /*Ez még nincs kész*/
            throw new NotImplementedException();
        }

        public BoatRentalsEntity GetBoatRentalsById()
        {
            throw new NotImplementedException();
        }

        public List<BoatRentalsEntity> GetTemplateBoatRents()
        {
            throw new NotImplementedException();
        }
    }
}
