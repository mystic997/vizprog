using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub.dao
{
    class BaseDao<T>
    {
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
