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

            BoatsDao bookableBoats = new BoatsDaoImpl();
            List<BoatsEntity> bookableBoatsList = bookableBoats.GetBookableBoats(startingDate, endingDate);
            for (int i = 0; i < bookableBoatsList.Count; i++)
            {
                var uc = new BookableBoatsUC();
                //uc.imImage = bookableBoatsList[i].BoatImage; // image??
                uc.lbName.Content = bookableBoatsList[i].BoatName;
                uc.lbType.Content = bookableBoatsList[i].BoatType;
                uc.lbOwner.Content = bookableBoatsList[i].FKOwner.MemberName;
                uc.lbWidth.Content = bookableBoatsList[i].BoatWidth;
                uc.lbHeight.Content = bookableBoatsList[i].BoatLength;
                uc.lbConsumption.Content = bookableBoatsList[i].Consumption;
                uc.lbMaxPerson.Content = bookableBoatsList[i].MaxPerson;
                uc.lbMaxSpeed.Content = bookableBoatsList[i].MaxSpeed;
                uc.lbDailyPrice.Content = bookableBoatsList[i].DailyPrice;

                BookableBoatsUCs.Add(uc);
            }
        }
    }
}
