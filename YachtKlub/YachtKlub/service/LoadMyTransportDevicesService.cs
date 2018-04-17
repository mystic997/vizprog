using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.dao;
using YachtKlub.entity;

namespace YachtKlub.service
{
    class LoadMyTransportDevicesService : ServiceResponse
    {
        private string email;

        public LoadMyTransportDevicesService(string email)
        {
            this.email = email;

            
            TransportDataCount();
            LoadMainTransportData();

        }

        private void TransportDataCount()
        {
            TransportDevicesDao transportDevicesDao = new TransportDevicesDaoImpl();
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity member = membersDao.getMemberByEmail(email);
            List<TransportDevicesEntity> myTransports = transportDevicesDao.GetAllTransportDevicesByOwner(member);
            ResponseMessage.Add("TransportsCount", Convert.ToString(myTransports.Count));
        }
        private void LoadMainTransportData()
        {
            TransportDevicesDao transportDevicesDao = new TransportDevicesDaoImpl();
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity member = membersDao.getMemberByEmail(email);
            List<TransportDevicesEntity> myTransports = transportDevicesDao.GetAllTransportDevicesByOwner(member);

            for (int i = 0; i < myTransports.Count; i++)
            {
                ResponseMessage.Add("TransportName" + Convert.ToString(i), myTransports[i].TransportDeviceName);
            }
            for (int i = 0; i < myTransports.Count; i++)
            {
                ResponseMessage.Add("TransportImage" + Convert.ToString(i), myTransports[i].TransportDeviceImage);
            }
            for (int i = 0; i < myTransports.Count; i++)
            {
                ResponseMessage.Add("TransportId" + Convert.ToString(i), Convert.ToString(myTransports[i].TransportDeviceId));
            }

        }
    }
}
