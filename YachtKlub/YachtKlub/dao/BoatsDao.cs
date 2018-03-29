using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    interface BoatsDao
    {
        BoatsEntity GetBoatsById();
        List<BoatsEntity> GetAllBoats();
        List<BoatsEntity> GetTemplateBoats();
    }
}
