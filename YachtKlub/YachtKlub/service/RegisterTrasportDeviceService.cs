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
    class RegisterTrasportDeviceService : ServiceResponse
    {
        DatabaseContext dbc;
        string email;

        public RegisterTrasportDeviceService(ref TransportDevicesEntity transportDevicesEntity)
        {
            RegisterService(ref transportDevicesEntity);

        }
        public void RegisterService(ref TransportDevicesEntity transportDevicesEntity)
        {
            dbc = AliveContext.Context;

            dbc.TransportDevices.Add(transportDevicesEntity);
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
