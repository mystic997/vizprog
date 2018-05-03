using System;
using System.Collections.Generic;
using YachtKlub.dao;
using YachtKlub.entity;

namespace YachtKlub.service
{
    class LoadMyBoatsService : ServiceResponse
{
    private string email;

    public LoadMyBoatsService(string email) {
        this.email = email;

            BoatDataCount();
            LoadMainBoatData();
        
            
    }

        private void BoatDataCount()
        {
            BoatsDao boatsDao = new BoatsDaoImpl();
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity member = membersDao.getMemberByEmail(email);
            List<BoatsEntity> myBoats = boatsDao.GetAllBoatsByOwner(member);
            ResponseMessage.Add("BoatsCount", Convert.ToString(myBoats.Count));
        }
        private void LoadMainBoatData()
    {
        BoatsDao boatsDao = new BoatsDaoImpl();
        MembersDao membersDao = new MembersDaoImpl();
        MembersEntity member = membersDao.getMemberByEmail(email);
        List<BoatsEntity> myBoats = boatsDao.GetAllBoatsByOwner(member);

        for (int i = 0; i < myBoats.Count; i++)
        {
            ResponseMessage.Add("boatName" + Convert.ToString(i), myBoats[i].BoatName);
        }
        for (int i = 0; i < myBoats.Count; i++)
        {
            ResponseMessage.Add("boatImage" + Convert.ToString(i), myBoats[i].BoatImage);
        }
            for (int i = 0; i < myBoats.Count; i++)
            {
                ResponseMessage.Add("boatId" + Convert.ToString(i), Convert.ToString(myBoats[i].BoatId));
            }


        }
   


       
}
}
