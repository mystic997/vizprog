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
            throw new NotImplementedException();
        }

        public BoatRentalsEntity GetBoatRentalsById(int v)
        {
            throw new NotImplementedException();
        }

        public List<BoatRentalsEntity> GetTemplateBoatRents()
        {
            throw new NotImplementedException();
        }
    }
}
