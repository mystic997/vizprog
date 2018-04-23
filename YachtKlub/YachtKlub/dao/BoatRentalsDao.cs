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
        List<BoatRentalsEntity> GetBoatRentalsByBoat(BoatsEntity RentedBoat);
        List<BoatRentalsEntity> GetBoatRentalsByWhoRents(MembersEntity WhoRents);
        List<BoatRentalsEntity> GetAllBoatRents();
        List<BoatRentalsEntity> GetTemplateBoatRents();
        int GetHowManyBoatRentalsByMonthAndBoat(int numberOfMonth, int id);
    }
}
