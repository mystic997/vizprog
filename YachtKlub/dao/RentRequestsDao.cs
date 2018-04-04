using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    interface RentRequestsDao
    {
        RentRequestsEntity GetRentRequestsById();
        List<RentRequestsEntity> GetAllRentRequests();
        List<RentRequestsEntity> GetAllRentRequestsByWhoBorrows(MembersEntity WhoBorrows);
        List<RentRequestsEntity> GetAllRentRequestsByBoatToBorrow(BoatsEntity BoatToBorrow);
        List<RentRequestsEntity> GetTemplateRentRequests();
    }
}
