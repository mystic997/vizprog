using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.dao;
using YachtKlub.entity;

namespace YachtKlub.service
{
    class LoadSelectedBoatService : ServiceResponse
    {
        private string id;

        public LoadSelectedBoatService(string id)
        {

            this.id = id;
            LoadSelectedBoat();

        }

        private void LoadSelectedBoat()
        {
            BoatsDao boatsDao = new BoatsDaoImpl();
            BoatsEntity boat = boatsDao.GetBoatsById(Convert.ToInt32(id));
            MembersDao membersDao = new MembersDaoImpl();
            MembersEntity member = membersDao.getMemberByBoat(boat);


            ResponseMessage.Add("BoatName", boat.BoatName);
            ResponseMessage.Add("BoatImage", boat.BoatImage);
            ResponseMessage.Add("BoatType", boat.BoatType);
            ResponseMessage.Add("DailyPrice", Convert.ToString(boat.DailyPrice));
            ResponseMessage.Add("WhereIsNowTheBoat", boat.WhereIsNowTheBoat);
            ResponseMessage.Add("IsLoan", Convert.ToString(boat.IsLoan));
            ResponseMessage.Add("MaxPerson", Convert.ToString(boat.MaxPerson));
            ResponseMessage.Add("MaxSpeed", Convert.ToString(boat.MaxSpeed));
            ResponseMessage.Add("DiveDepth", Convert.ToString(boat.DiveDepth));
            ResponseMessage.Add("Consumption", Convert.ToString(boat.Consumption));
            ResponseMessage.Add("YearOfManufacture", Convert.ToString(boat.YearOfManufacture));
            ResponseMessage.Add("BoatLength", Convert.ToString(boat.BoatLength));
            ResponseMessage.Add("BoatWidth", Convert.ToString(boat.BoatWidth));
            


            /*Member Adatok, ha az is kellene, például a foglalásnál*/

            ResponseMessage.Add("email", member.Email);
            ResponseMessage.Add("password", member.Password);
            ResponseMessage.Add("permission", member.Permission.ToString());

            char[] delimiter = { ' ' };
            string[] memberName = member.MemberName.Split(delimiter);
            string[] firstnameaArray = memberName.Take(memberName.Count() - 1).ToArray();
            string firstname = string.Join(" ", firstnameaArray);
            string lastname = memberName.Last();
            ResponseMessage.Add("firstname", firstname);
            ResponseMessage.Add("lastname", lastname);

            ResponseMessage.Add("country", member.Country);
            ResponseMessage.Add("city", member.City);
            ResponseMessage.Add("street", member.Street);
            ResponseMessage.Add("houseNumber", member.HouseNumber);
            ResponseMessage.Add("MemberImage", member.MemberImage);

            /* ^^Member Adatok, ha az is kellene, például a foglalásnál*/
        }
    }
}
