using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    interface BoatRentalsDao
    {
        BoatRentalsEntity GetBoatRentalsById();
        List<BoatRentalsEntity> GetAllBoatRents();
        List<BoatRentalsEntity> GetTemplateBoatRents();
    }
}
