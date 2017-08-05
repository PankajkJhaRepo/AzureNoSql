using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBusinessModel
{
    public interface IDeviceBLL<E>
      where E : DeviceReading  
    {
        List<E> GetAllReadings(string DeviceId);
        E GetReading(string Id,string DeviceId);
        bool Save(E reading);
        bool Update(E reading);
        bool Delete(E reading);
    }
}
