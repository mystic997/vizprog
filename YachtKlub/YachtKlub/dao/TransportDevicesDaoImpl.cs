using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    class TransportDevicesDaoImpl : BaseDao<TransportDevicesEntity>, TransportDevicesDao
    {
        public List<TransportDevicesEntity> GetAllTransportDevices()
        {
            var linqQuery = from row in dbc.TransportDevices select row;
            List<TransportDevicesEntity> TransportDevicesList = linqQuery.ToList();
            return TransportDevicesList;
        }

        public List<TransportDevicesEntity> GetTemplateTransportDevices()
        {
            Random random = new Random();
            List<TransportDevicesEntity> TransportDevices = new List<TransportDevicesEntity>();

            for (int i = 0; i < 12; i++)
            {
                TransportDevicesEntity TemplateTransportDevice = new TransportDevicesEntity();

                TemplateTransportDevice.TransportDeviceId = i;
                TemplateTransportDevice.TransportDeviceName = "TransportDevice" + i;
                TemplateTransportDevice.CarryingCapacity = random.Next(1, 50);
                TemplateTransportDevice.TransportDeviceType = "Type" + random.Next(0, 3);
                TemplateTransportDevice.TransportDeviceLength = random.Next(100, 700) / 100;
                TemplateTransportDevice.TransportDeviceWidth = random.Next(50, 300) / 100;
                TemplateTransportDevice.TransportDeviceImage = "TransportDevice" + i;

                // FK's
                MembersDao mem = new MembersDaoImpl();
                List<MembersEntity> mems = mem.GetAllMembers();
                TemplateTransportDevice.FKOwner = mems[random.Next(0, mems.Count)];
                TemplateTransportDevice.BoatRentals = new List<BoatRentalsEntity>();
                TemplateTransportDevice.RentRequests = new List<RentRequestsEntity>();

                TransportDevices.Add(TemplateTransportDevice);
            }

            return TransportDevices;
        }

        public List<TransportDevicesEntity> GetAllTransportDevicesByOwner(MembersEntity Owner)/*Függvény, ami visszaad egy listát, ami tartalmazza, hogy az adott felhasználónak, milyen szállító eszközei vannak*/
        {
            var linqQuery = from row in dbc.TransportDevices where row.FKOwner.MemberId.Equals(Owner.MemberId) select row;
            List<TransportDevicesEntity> TransportDevicesList = linqQuery.ToList();
            return TransportDevicesList;
        }

        public TransportDevicesEntity GetTransportDevicesById(int id)
        {
            var linqQuery = from row in dbc.TransportDevices where row.TransportDeviceId.Equals(id) select row;
            List<TransportDevicesEntity> TransportDevicesList = linqQuery.ToList();
            TransportDevicesEntity TransportDevices = GetSingleResultWithoutExc(TransportDevicesList);
            return TransportDevices;
        }
    }
}
