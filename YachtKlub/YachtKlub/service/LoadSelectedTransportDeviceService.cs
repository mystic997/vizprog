using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.dao;
using YachtKlub.entity;

namespace YachtKlub.service
{
    class LoadSelectedTransportDeviceService : ServiceResponse
    {
        private string id;

        public LoadSelectedTransportDeviceService(string id)
        {

            this.id = id;
            LoadSelectedTransportDevice();

        }

        private void LoadSelectedTransportDevice()
        {
            TransportDevicesDao transportDevicesDao = new TransportDevicesDaoImpl();
            TransportDevicesEntity transportDevice = transportDevicesDao.GetTransportDevicesById(Convert.ToInt32(id));
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity member = membersDao.getMemberBTransportDevice(transportDevice);


            ResponseMessage.Add("TransportDeviceName", transportDevice.TransportDeviceName);
            ResponseMessage.Add("CarryingCapacity", Convert.ToString(transportDevice.CarryingCapacity));
            ResponseMessage.Add("TransportDeviceType", Convert.ToString(transportDevice.TransportDeviceType));
            ResponseMessage.Add("TransportDeviceLength", Convert.ToString(transportDevice.TransportDeviceLength));
            ResponseMessage.Add("TransportDeviceWidth", Convert.ToString(transportDevice.TransportDeviceWidth));
            ResponseMessage.Add("TransportDeviceImage", Convert.ToString(transportDevice.TransportDeviceImage));
         


            /*Member Adatok, ha az is kellene, például a foglalásnál*/

            ResponseMessage.Add("email", member.Email);
            ResponseMessage.Add("password", member.Password);
            ResponseMessage.Add("permission", member.Permission.ToString());

            char[] delimiter = { ' ' };
            string[] memberName = member.MemberName.Split(delimiter);
            string[] firstnameaArray = memberName.Take(memberName.Count() - 1).ToArray();
            string firstname = string.Join(" ", firstnameaArray);
            string lastname = memberName.Last();
            ResponseMessage.Add("firstname", firstname);
            ResponseMessage.Add("lastname", lastname);

            ResponseMessage.Add("country", member.Country);
            ResponseMessage.Add("city", member.City);
            ResponseMessage.Add("street", member.Street);
            ResponseMessage.Add("houseNumber", member.HouseNumber);
            ResponseMessage.Add("MemberImage", member.MemberImage);

            /* ^^Member Adatok, ha az is kellene, például a foglalásnál*/
        }
    }
}
