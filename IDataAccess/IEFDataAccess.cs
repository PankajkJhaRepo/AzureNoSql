using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess
{
   public interface IEFDataAccess<E>
     where E : BaseEFEntity
    {

        List<E> GetAll();

        bool Save(E entity);

        bool SaveBatch(List<E> entities);
    }
}
