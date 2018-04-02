using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    class TransportDevicedImpl : BaseDao<TransportDevicesEntity>, TransportDevicesDao
    {
        DatabaseContext dbc;

        public TransportDevicedImpl()
        {
            dbc = new DatabaseContext();
        }

        public List<TransportDevicesEntity> GetAllTransportDevices()
        {
            var linqQuery = from row in dbc.TransportDevices select row;
            List<TransportDevicesEntity> TransportDevicesList = linqQuery.ToList();
            return TransportDevicesList;
        }

        public List<TransportDevicesEntity> GetTemplateTransportDevices()
        {
            List<TransportDevicesEntity> TransportDevices = new List<TransportDevicesEntity>();

            for (int i = 0; i < 12; i++)
            {
                Random random = new Random();

                TransportDevicesEntity TemplateTransportDevice = new TransportDevicesEntity();

                TemplateTransportDevice.TransportDeviceId = i;
                TemplateTransportDevice.TransportDeviceName = "TransportDevice" + i;
                TemplateTransportDevice.CarryingCapacity = random.Next(1, 50);
                TemplateTransportDevice.TransportDeviceType = "Type" + random.Next(0, 3);
                TemplateTransportDevice.TransportDeviceLength = random.Next(100, 700) / 100;
                TemplateTransportDevice.TransportDeviceWidth = random.Next(50, 300) / 100;
                TemplateTransportDevice.TransportDeviceImage = "TransportDevice" + i;

                MembersDao mem = new MembersDaoImpl();
                List<MembersEntity> mems = mem.GetTemplateMembers();


                TemplateTransportDevice.FKOwner = mems[random.Next(0, mems.Count)];//ez elvileg jó így

                

                TemplateTransportDevice.BoatRentals = new List<BoatRentalsEntity>();//Ez csak ideiglenes
                TemplateTransportDevice.RentRequests = new List<RentRequestsEntity>();//Ez csak ideiglenes

                TransportDevices.Add(TemplateTransportDevice);
                
            }
            return TransportDevices;
            //throw new NotImplementedException();
        }

        public List<TransportDevicesEntity> GetAllTransportDevicesByOwner(MembersEntity Owner)/*Függvény, ami visszaad egy listát, ami tartalmazza, hogy az adott felhasználónak, milyen szállító eszközei vannak*/
        {
            var linqQuery = from row in dbc.TransportDevices where row.FKOwner.Equals(Owner) select row;
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
