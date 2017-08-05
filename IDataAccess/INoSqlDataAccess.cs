using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccess
{
   public interface INoSqlDataAccess<E>
        where E : class

    {

        List<E> GetAll();
        List<E> GetAllReadings(string DeviceId);
        E GetReading(string Id, string DeviceId);
        bool Save(E entity);

        bool SaveBatch(List<E> entities);
    }
}
