using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.entity
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("YachtKlubDB")
        {
            /*Database.Delete();
            Database.Create();*/
            //Database.Delete();
            //Database.Create();
            //Database.SetInitializer(new DropCreateDatabaseAlways<DatabaseContext>());
        }

        public DbSet<MembersEntity> Members { get; set; }
        public DbSet<BoatsEntity> Boats { get; set; }
        public DbSet<BoatRentalsEntity> BoatRentals { get; set; }
        public DbSet<TransportDevicesEntity> TransportDevices { get; set; }
        public DbSet<RentRequestsEntity> RentRequests { get; set; }

    }
}
