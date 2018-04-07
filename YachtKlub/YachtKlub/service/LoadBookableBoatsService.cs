using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.dao;
using YachtKlub.entity;

namespace YachtKlub.service
{
    class LoadBookableBoatsService : ServiceResponse
    {
        public BookableBoatsUC BookableBoatsUC { get; set; }
        public static List<BoatsEntity> BookableBoats { get; set; }

        public LoadBookableBoatsService(DateTime startingDate, DateTime endingDate)
        {
            BookableBoatsUC = new BookableBoatsUC();

            // ki kell valasztani azokat a halyokat, melyek:
            /*
             - a startingDate nagyobb, mint a BoatRentals tablanak az endingDate-je
             - az endingDate kisebb, mint a Boatrentals tablanak a startingDate-je
             - foglalhato a hajo (isLoan mezo a Boats tablabol)
             */

            BoatsDao bookableBoats = new BoatsDaoImpl();
            BookableBoats = bookableBoats.GetBookableBoats(startingDate, endingDate);

            for (int i = 0; i < BookableBoats.Count; i++)
            {
                BookableBoatsUC.lbBookalbeShipsUC.Items.Add(BookableBoats[i].BoatName);
            }
        }
    }
}
