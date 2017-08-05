using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using App.CosmodbStorage;

namespace NoSqlDataAccess
{
    public class DeviceReadingDataAccess<T> : INoSqlDataAccess<Entity.DeviceReading>
    {
        public List<DeviceReading> GetAll()
        {
            throw new NotImplementedException();
        }
        public List<DeviceReading> Get(string DeviceId)
        {
            DocumentdbService<DeviceReading> service = new DocumentdbService<DeviceReading>();
            return service.Get(DeviceId);
        }
        public DeviceReading Get(string Id, string DeviceId)
        {
            DocumentdbService<DeviceReading> service = new DocumentdbService<DeviceReading>();
            return service.Get(Id,DeviceId);
        }

        public  bool Save(DeviceReading reading)
        {
            DocumentdbService<DeviceReading> service = new DocumentdbService<DeviceReading>();
           // return service.CreateDatabase().Result;
            return  service.Create(reading);
        }

        public bool SaveBatch(List<DeviceReading> entities)
        {
            DocumentdbService<DeviceReading> service = new DocumentdbService<DeviceReading>();
            return service.CreateDatabase().Result;
        }

        public List<DeviceReading> GetAllReadings(string DeviceId)
        {
            DocumentdbService<DeviceReading> service = new DocumentdbService<DeviceReading>();
            return service.Get(DeviceId);
        }

        public DeviceReading GetReading(string Id, string DeviceId)
        {
            DocumentdbService<DeviceReading> service = new DocumentdbService<DeviceReading>();
            return service.Get(Id,DeviceId);
        }
    }
}
