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
    class AcceptRequesttService : ServiceResponse
    {
        DatabaseContext dbc;
        string email;

        public AcceptRequesttService(ref BoatRentalsEntity boatRentalsEntity)
        {
            RegisterService(ref boatRentalsEntity);

        }
        public void RegisterService(ref BoatRentalsEntity boatRentalsEntity)
        {
            dbc = AliveContext.Context;

            dbc.BoatRentals.Add(boatRentalsEntity);
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

