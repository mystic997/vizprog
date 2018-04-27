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

        public RegisterBoatService(ref BoatsEntity boatsEntity)
        {
            RegisterService(ref boatsEntity);

        }
        public void RegisterService(ref BoatsEntity boatsEntity)
        {
            dbc = AliveContext.Context;

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
