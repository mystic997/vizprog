using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.database
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("YachtKlubDB")
        {
            /*Database.Delete();
            Database.Create();*/
            Database.Delete();
            Database.Create();
            //Database.SetInitializer(new DropCreateDatabaseAlways<DatabaseContext>());
        }

        public DbSet<Members> Members { get; set; }
        public DbSet<Boats> Boats { get; set; }
    }
}
