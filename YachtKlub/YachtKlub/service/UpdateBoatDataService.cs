using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.dao;
using YachtKlub.entity;
using YachtKlub.validator;

namespace YachtKlub.service
{
    class UpdateBoatDataService : ServiceResponse
    {
        private int BoatId;
        private string BoatName;
        private string BoatType;
        private double DailyPrice;
        private string WhereIsNowTheBoat;
        private bool IsLoan;
        private int MaxPerson;
        private double MaxSpeed;
        private double DiveDepth;
        private double Consumption;
        private int YearOfManufacture;
        private double BoatLength;
        private double BoatWidth;
        private string BoatImage;
        DatabaseContext dbc;


        public UpdateBoatDataService(int BoatId, string BoatName, string BoatType, double DailyPrice, string WhereIsNowTheBoat, bool IsLoan, int MaxPerson, double MaxSpeed, double DiveDepth, double Consumption, int YearOfManufacture, double BoatLength, double BoatWidth, string BoatImage)
        {
            this.BoatId = BoatId;
            this.BoatName = BoatName;
            this.BoatType = BoatType;
            this.DailyPrice = DailyPrice;
            this.WhereIsNowTheBoat = WhereIsNowTheBoat;
            this.IsLoan = IsLoan;
            this.MaxPerson = MaxPerson;
            this.MaxSpeed = MaxSpeed;
            this.DiveDepth = DiveDepth;
            this.Consumption = Consumption;
            this.YearOfManufacture = YearOfManufacture;
            this.BoatLength = BoatLength;
            this.BoatWidth = BoatWidth;
            this.BoatImage = BoatImage;

            dbc = AliveContext.Context;

            UpdateBoat();

        }

        private void UpdateBoat()
        {
            BoatsEntity boatData  = dbc.Boats.SingleOrDefault(m => m.BoatId.Equals(BoatId));
            boatData.BoatId = this.BoatId;
            boatData.BoatName = this.BoatName;
            boatData.BoatType = this.BoatType;
            boatData.DailyPrice = this.DailyPrice;
            boatData.WhereIsNowTheBoat = this.WhereIsNowTheBoat;
            boatData.IsLoan = this.IsLoan;
            boatData.MaxPerson = this.MaxPerson;
            boatData.MaxSpeed = this.MaxSpeed;
            boatData.DiveDepth = this.DiveDepth;
            boatData.Consumption = this.Consumption;
            boatData.YearOfManufacture = this.YearOfManufacture;
            boatData.BoatLength = this.BoatLength;
            boatData.BoatWidth = this.BoatWidth;
            boatData.BoatImage = this.BoatImage;

            dbc.SaveChanges();

            FeedbackMessage = "Adatok sikeresen módosítva!";
            ServiceStatus = Status.OK;

            // it must be a method
            if (!string.IsNullOrEmpty(FeedbackMessage) && !string.IsNullOrWhiteSpace(FeedbackMessage))
            {
                new PrintMessageBox(FeedbackMessage, ServiceStatus);
            }

        }
    }
}
