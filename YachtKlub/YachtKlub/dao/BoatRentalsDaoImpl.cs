using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Globalization;
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

        public List<BoatRentalsEntity>
            GetBoatRentalsByBoat(
                BoatsEntity RentedBoat) /*Függvény, ami visszaad egy listát, ami tartalmazza, hogy az adott hajóhoz milyen kölcsönzések vannak*/
        {
            var linqQuery = from row in dbc.BoatRentals where row.FKRentedBoat.Equals(RentedBoat) select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList;
        }

        public List<BoatRentalsEntity>
            GetBoatRentalsByWhoRents(
                MembersEntity WhoRents) /*Függvény, ami visszaad egy listát, ami tartalmazza, hogy az adott felhaszálónak milyen kölcsönzései vannak*/
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
            Random random = new Random();
            List<BoatRentalsEntity> TemplateBoatRentals = new List<BoatRentalsEntity>();
            int a = 500;
            for (int i = 0; i < a; i++)
            {
                BoatRentalsEntity TemplateBoatRental = new BoatRentalsEntity();
                TemplateBoatRental.BoatRentalsId = generateID();
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

            for (int i = 0; i < a; i++)
            {
                int temp = random.Next(1, 12);
                int temp2 = random.Next(1, 12);
                int temp3 = temp2 + random.Next(1, 12);

                TemplateBoatRentals[i].StartingDate = new DateTime(2018, temp, temp2);
                TemplateBoatRentals[i].EndDate = new DateTime(2018, temp, temp3);

            }



            return TemplateBoatRentals;
        }

        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        public List<BoatRentalsEntity> GeBoatRentalsByBoatId(int id)
        {
            var linqQuery = from row in dbc.BoatRentals where row.FKRentedBoat.BoatId.Equals(id) select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList;
        }

        public int GetHowManyBoatRentalsByYearAndBoat(int year, int id)
        {
            var linqQuery = from row in dbc.BoatRentals
                where (row.StartingDate.Year.Equals(year) & row.FKRentedBoat.BoatId.Equals(id))
                select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList.Count;
        }

        public int GetHowManyBoatRentalsByMonthAndBoat(int month, int id)
        {
            var linqQuery = from row in dbc.BoatRentals
                where (row.StartingDate.Month.Equals(month) & row.FKRentedBoat.BoatId.Equals(id))
                select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList.Count;
        }

        public int GetHowManyBoatRentalsByWeekAndBoat(int week, int id)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar calendar = dfi.Calendar;

            var linqQuery = from row in dbc.BoatRentals where row.FKRentedBoat.BoatId.Equals(id) select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            int RentalCount = 0;
            for (int i = 0; i < BoatRentalsList.Count; i++)
            {
                if (calendar.GetWeekOfYear(BoatRentalsList[i].StartingDate, dfi.CalendarWeekRule, DayOfWeek.Monday)
                    .Equals(week))
                {
                    RentalCount++;
                }

            }

            return RentalCount;
        }

        public int GetHowManyBoatRentalsByDayAndBoat(int day, int id)
        {
            var linqQuery = from row in dbc.BoatRentals
                where (row.StartingDate.Day.Equals(day) & row.FKRentedBoat.BoatId.Equals(id))
                select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList.Count;
        }

        public List<BoatRentalsEntity> GetBoatRentalsByMonthAndBoat(int month, int id)
        {
            var linqQuery = from row in dbc.BoatRentals
                where (row.StartingDate.Month.Equals(month) & row.FKRentedBoat.BoatId.Equals(id))
                select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList;
        }

        public List<BoatRentalsEntity> GetBoatRentalsByYearAndBoat(int year, int id)
        {
            var linqQuery = from row in dbc.BoatRentals
                where (row.StartingDate.Year.Equals(year) & row.FKRentedBoat.BoatId.Equals(id))
                select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList;
        }

        public List<BoatRentalsEntity> GetBoatRentalsByWeekAndBoat(int week, int id)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar calendar = dfi.Calendar;
            List<BoatRentalsEntity> ReturnList = new List<BoatRentalsEntity>();
            var linqQuery = from row in dbc.BoatRentals where row.FKRentedBoat.BoatId.Equals(id) select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            int RentalCount = 0;
            for (int i = 0; i < BoatRentalsList.Count; i++)
            {
                if (calendar.GetWeekOfYear(BoatRentalsList[i].StartingDate, dfi.CalendarWeekRule, DayOfWeek.Monday)
                    .Equals(week))
                {
                    ReturnList.Add(BoatRentalsList[i]);
                }

            }

            return ReturnList;
        }

        public List<BoatRentalsEntity> GetBoatRentalsByDayAndBoat(int day, int id)
        {
            var linqQuery = from row in dbc.BoatRentals
                where (row.StartingDate.Day.Equals(day) & row.FKRentedBoat.BoatId.Equals(id))
                select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            return BoatRentalsList;
            ;
        }


        public int GetIncomeBoatRentalsByYearAndBoat(int year, int id)
        {
            var linqQuery = from row in dbc.BoatRentals
                where (row.StartingDate.Year.Equals(year) & row.FKRentedBoat.BoatId.Equals(id))
                select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            BoatsDaoImpl boatsDaoImpl = new BoatsDaoImpl();
            BoatsEntity boatsEntity = boatsDaoImpl.GetBoatsById(id);

            int Income = 0;
            for (int i = 0; i < BoatRentalsList.Count; i++)
            {
                Income += ( BoatRentalsList[i].EndDate - BoatRentalsList[i].StartingDate).Days *
                           Convert.ToInt32(boatsEntity.DailyPrice);

            }

            return Income;
        }

        public int GetIncomeBoatRentalsByMonthAndBoat(int month, int id)
        {
            var linqQuery = from row in dbc.BoatRentals
                where (row.StartingDate.Month.Equals(month) & row.FKRentedBoat.BoatId.Equals(id))
                select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            BoatsDaoImpl boatsDaoImpl = new BoatsDaoImpl();
            BoatsEntity boatsEntity = boatsDaoImpl.GetBoatsById(id);

            int Income = 0;
            for (int i = 0; i < BoatRentalsList.Count; i++)
            {
                Income += (BoatRentalsList[i].EndDate - BoatRentalsList[i].StartingDate).Days *
                           Convert.ToInt32(boatsEntity.DailyPrice);

            }

            return Income;
        }

        public int GetIncomeBoatRentalsByWeekAndBoat(int week, int id)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar calendar = dfi.Calendar;

            var linqQuery = from row in dbc.BoatRentals where row.FKRentedBoat.BoatId.Equals(id) select row;
            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            int RentalCount = 0;
            int Income = 0;
            for (int i = 0; i < BoatRentalsList.Count; i++)
            {
                if (calendar.GetWeekOfYear(BoatRentalsList[i].StartingDate, dfi.CalendarWeekRule, DayOfWeek.Monday)
                    .Equals(week))
                {

                    List<BoatRentalsEntity> BoatRentalsList2 = linqQuery.ToList();
                    BoatsDaoImpl boatsDaoImpl = new BoatsDaoImpl();
                    BoatsEntity boatsEntity = boatsDaoImpl.GetBoatsById(id);

                    
                    for (int g = 0; g < BoatRentalsList2.Count; g++)
                    {
                        Income += (BoatRentalsList[i].EndDate - BoatRentalsList[i].StartingDate).Days *
                                   Convert.ToInt32(boatsEntity.DailyPrice);

                    }

                    
                }

            }
            return Income;
        }


        public int GetIncomeBoatRentalsByDayAndBoat(int day, int month, int id)
        {
            var linqQuery = from row in dbc.BoatRentals
                where (row.StartingDate.Day.Equals(day) & row.StartingDate.Month.Equals(month) & row.FKRentedBoat.BoatId.Equals(id))
                select row;

            List<BoatRentalsEntity> BoatRentalsList = linqQuery.ToList();
            BoatsDaoImpl boatsDaoImpl = new BoatsDaoImpl();
            BoatsEntity boatsEntity = boatsDaoImpl.GetBoatsById(id);

            int Income = 0;
            for (int i = 0; i < BoatRentalsList.Count; i++)
            {
                Income += (BoatRentalsList[i].EndDate - BoatRentalsList[i].StartingDate).Days *
                           Convert.ToInt32(boatsEntity.DailyPrice);

            }

            return Income;
        }
    
}
}
