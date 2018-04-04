using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    interface TransportDevicesDao
    {
        TransportDevicesEntity GetTransportDevicesById(int id);
        List<TransportDevicesEntity> GetAllTransportDevicesByOwner(MembersEntity Owner);
        List<TransportDevicesEntity> GetAllTransportDevices();
        List<TransportDevicesEntity> GetTemplateTransportDevices();
    }
}
