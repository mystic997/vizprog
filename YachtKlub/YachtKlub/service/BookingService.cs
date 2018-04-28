using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.dao;
using YachtKlub.entity;
using YachtKlub.validator;

namespace YachtKlub.service
{
    class BookingService : ServiceResponse
    {
        private string fromWhere;
        private string toWhere;
        private string whoBorrowsEmail;
        private int numberOfPersons;
        private DateTime from;
        private DateTime to;
        private BoatsEntity boatToBorrow;

        DatabaseContext dbc;

        public BookingService(string whoBorrowsEmail, DateTime from, DateTime to, BoatsEntity boatToBorrow, string fromWhere, string toWhere, int numberOfPersons)
        {
            this.fromWhere = fromWhere;
            this.toWhere = toWhere;
            this.numberOfPersons = numberOfPersons;
            this.from = from;
            this.to = to;
            this.boatToBorrow = boatToBorrow;
            this.whoBorrowsEmail = whoBorrowsEmail;

            dbc = AliveContext.Context;

            TryToBook();
        }

        private void TryToBook()
        {
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity whoBorrows = membersDao.getMemberByEmail(whoBorrowsEmail);

            RentRequestsEntity rentRequest = new RentRequestsEntity();
            rentRequest.BoatToBorrow = boatToBorrow;
            //to DO deviceBorrow
            rentRequest.DeviceToBorrow = null;
            rentRequest.StartingDate = from;
            rentRequest.EndDate = to;
            rentRequest.FromWhere = fromWhere;
            rentRequest.ToWhere = toWhere;
            rentRequest.WhoBorrows = whoBorrows;
            rentRequest.Status = 1;

            dbc.RentRequests.Add(rentRequest);
            dbc.SaveChanges();

            FeedbackMessage = "Foglalás kérés jelezve a tulajdonos felé!";
            ServiceStatus = Status.OK;

            // it must be a method
            if (!string.IsNullOrEmpty(FeedbackMessage) && !string.IsNullOrWhiteSpace(FeedbackMessage))
            {
                new PrintMessageBox(FeedbackMessage, ServiceStatus);
            }
        }
    }
}
