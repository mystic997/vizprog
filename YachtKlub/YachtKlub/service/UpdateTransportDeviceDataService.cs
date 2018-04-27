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
    class UpdateTransportDeviceDataService : ServiceResponse
    {

        private int TransportDeviceId;
        private string TransportDeviceName;
        private double CarryingCapacity;
        private string TransportDeviceType;
        private double TransportDeviceLength;
        private double TransportDeviceWidth;
        private string TransportDeviceImage;
        DatabaseContext dbc;


        public UpdateTransportDeviceDataService(
            int TransportDeviceId,
            string TransportDeviceName,
            double CarryingCapacity,
            string TransportDeviceType,
            double TransportDeviceLength,
            double TransportDeviceWidth,
            string TransportDeviceImage)
        {
            this.TransportDeviceId = TransportDeviceId;
            this.TransportDeviceName = TransportDeviceName;
            this.CarryingCapacity = CarryingCapacity;
            this.TransportDeviceType = TransportDeviceType;
            this.TransportDeviceLength = TransportDeviceLength;
            this.TransportDeviceWidth = TransportDeviceWidth;
            this.TransportDeviceImage = TransportDeviceImage;

            dbc = AliveContext.Context;
            UpdateTransportDeviceData();
        }

        public void UpdateTransportDeviceData()
        {
            dbc = AliveContext.Context;
            TransportDevicesEntity transportDeviceData = dbc.TransportDevices.SingleOrDefault(m => m.TransportDeviceId.Equals(TransportDeviceId));

            transportDeviceData.TransportDeviceId = this.TransportDeviceId;
              transportDeviceData.TransportDeviceName = this.TransportDeviceName;
              transportDeviceData.CarryingCapacity = this.CarryingCapacity;
              transportDeviceData.TransportDeviceType = this.TransportDeviceType;
              transportDeviceData.TransportDeviceLength = this.TransportDeviceLength;
              transportDeviceData.TransportDeviceWidth = this.TransportDeviceWidth;
              transportDeviceData.TransportDeviceImage = this.TransportDeviceImage;

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
