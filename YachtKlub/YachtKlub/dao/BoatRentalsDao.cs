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
        int GetHowManyBoatRentalsByMonthAndBoat(int month, int id);
        int GetHowManyBoatRentalsByYearAndBoat(int year, int id);
        int GetHowManyBoatRentalsByWeekAndBoat(int week, int id);
        int GetHowManyBoatRentalsByDayAndBoat(int day, int id);
        List<BoatRentalsEntity> GetBoatRentalsByMonthAndBoat(int month, int id);
        List<BoatRentalsEntity> GetBoatRentalsByYearAndBoat(int year, int id);
        List<BoatRentalsEntity> GetBoatRentalsByWeekAndBoat(int week, int id);
        List<BoatRentalsEntity> GetBoatRentalsByDayAndBoat(int day, int id);
        List<BoatRentalsEntity> GeBoatRentalsByBoatId(int id);
        int GetIncomeBoatRentalsByMonthAndBoat(int month, int id);
        int GetIncomeBoatRentalsByYearAndBoat(int year, int id);
        int GetIncomeBoatRentalsByWeekAndBoat(int week, int id);
        int GetIncomeBoatRentalsByDayAndBoat(int day, int month, int id);

    }
}
