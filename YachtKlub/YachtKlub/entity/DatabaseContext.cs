using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.entity
{
    class DatabaseContext : System.Data.Entity.DbContext
    {
        public DatabaseContext() : base("YachtKlubDB")
        {
        }

        public DbSet<MembersEntity> Members { get; set; }
        public DbSet<BoatsEntity> Boats { get; set; }
        public DbSet<BoatRentalsEntity> BoatRentals { get; set; }
        public DbSet<TransportDevicesEntity> TransportDevices { get; set; }
        public DbSet<RentRequestsEntity> RentRequests { get; set; }

    }
}
