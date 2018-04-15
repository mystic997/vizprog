using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.dao;
using YachtKlub.entity;

namespace YachtKlub.service
{
    class LoadMyBoatsAndTransportsService : ServiceResponse
{
    private string email;
    public LoadMyBoatsAndTransportsService(string email) {
        this.email = email;

            BoatDataCount();
            TransportDataCount();
        LoadMainBoatData();
        LoadMainTransportData();
            
    }

        private void BoatDataCount()
        {
            BoatsDao boatsDao = new BoatsDaoImpl();
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity member = membersDao.getMemberByEmail(email);
            List<BoatsEntity> myBoats = boatsDao.GetAllBoatsByOwner(member);
            ResponseMessage.Add("BoatsCount", Convert.ToString(myBoats.Count));
        }
        private void LoadMainBoatData()
    {
        BoatsDao boatsDao = new BoatsDaoImpl();
        MembersDao membersDao = new MembersDaoImpl();
        MembersEntity member = membersDao.getMemberByEmail(email);
        List<BoatsEntity> myBoats = boatsDao.GetAllBoatsByOwner(member);

        for (int i = 0; i < myBoats.Count; i++)
        {
            ResponseMessage.Add("boatName" + Convert.ToString(i), myBoats[i].BoatName);
        }
        for (int i = 0; i < myBoats.Count; i++)
        {
            ResponseMessage.Add("boatImage" + Convert.ToString(i), myBoats[i].BoatImage);
        }


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

    }
}
}
