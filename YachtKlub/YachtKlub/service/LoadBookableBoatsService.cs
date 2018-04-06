using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.service
{
    class LoadBookableBoatsService : ServiceResponse
    {
        public List<BookableBoatsUC> BookableBoatsUCs { get; set; }

        public LoadBookableBoatsService(DateTime startingDate, DateTime endingDate)
        {
            BookableBoatsUCs = new List<BookableBoatsUC>();
            // ki kell valasztani azokat a halyokat, melyek:
            /*
             - a startingDate nagyobb, mint a BoatRentals tablanak az endingDate-je
             - az endingDate kisebb, mint a Boatrentals tablanak a startingDate-je
             - foglalhato a hajo (isLoan mezo a Boats tablabol)
             */
        }
    }
}
