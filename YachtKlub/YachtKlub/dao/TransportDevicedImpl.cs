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
            throw new NotImplementedException();
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
