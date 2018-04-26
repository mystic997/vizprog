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
    class RegisterBoatService : ServiceResponse
    {
        DatabaseContext dbc;
        string email;

        public RegisterBoatService(string email) { this.email = email; }
        public void RegisterService(ref NewBoatWindow newBoatWindow)
        {
            BoatsDao boatsDao = new BoatsDaoImpl();
            BoatsEntity boatsEntity = new BoatsEntity();

            boatsEntity.BoatId = dbc.Boats.OrderByDescending(u => u.BoatId).FirstOrDefault().BoatId;
            boatsEntity.BoatImage = newBoatWindow.imgBoatPicture.Tag.ToString();
            boatsEntity.BoatLength = Convert.ToInt32(newBoatWindow.tbBoatLenght.Text);
            boatsEntity.BoatWidth = Convert.ToInt32(newBoatWindow.tbBoatWidth.Text);
            boatsEntity.BoatName = newBoatWindow.tbBoatName.Text;
            //boatsEntity.BoatRentals = null;
            boatsEntity.BoatType = newBoatWindow.tbBoatType.Text;
            boatsEntity.Consumption = Convert.ToInt32(newBoatWindow.tbBoatConsumption.Text);
            boatsEntity.DailyPrice = Convert.ToInt32(newBoatWindow.tbBoatPrice.Text);
            boatsEntity.DiveDepth = Convert.ToInt32(newBoatWindow.tbBoatDept.Text);

            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity member = membersDao.getMemberByEmail(email);

            boatsEntity.FKOwner = member;
            boatsEntity.IsLoan = newBoatWindow.tbIsLoan.IsChecked ?? false;
            boatsEntity.MaxPerson = Convert.ToInt32(newBoatWindow.tbBoatManpower.Text);
            boatsEntity.MaxSpeed = Convert.ToInt32(newBoatWindow.tbBoatSpeed.Text);
            boatsEntity.WhereIsNowTheBoat = newBoatWindow.tbBoatPlace.Text;
            boatsEntity.YearOfManufacture = Convert.ToInt32(newBoatWindow.tbBoatYear.Text);
            dbc.Boats.Add(boatsEntity);
            dbc.SaveChanges();

            FeedbackMessage = "Sikeres regisztráció!";
            ServiceStatus = Status.OK;


            // it must be a method
            if (!string.IsNullOrEmpty(FeedbackMessage) && !string.IsNullOrWhiteSpace(FeedbackMessage))
            {
                new PrintMessageBox(FeedbackMessage, ServiceStatus);
            }
        }
    }
}
