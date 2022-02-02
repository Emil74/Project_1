using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    interface IORM<T>
    {
        DataTable Select();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int Id);

    }
}
