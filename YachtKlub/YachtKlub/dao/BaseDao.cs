using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YachtKlub.entity;

namespace YachtKlub.dao
{
    class BaseDao<T>
    {
        protected DatabaseContext dbc;

        public BaseDao()
        {
            //dbc = new DatabaseContext();
            dbc = AliveContext.Context;
        }

        public T GetSingleResultWithoutExc(List<T> values)
        {
            T result = default(T);

            if (values.Count != 0)
            {
                result = values.First();
            }

            return result;
        }

    }
}
