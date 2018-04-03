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
        TransportDevicesEntity GetTransportDevicesById();
        List<TransportDevicesEntity> GetAllTransportDevices();
        List<TransportDevicesEntity> GetTemplateTransportDevices();
    }
}
