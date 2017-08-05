using BusinessModel.Factory;
using Entity;
using IBusinessModel;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Device
{
   public class DeviceBLL<T> : IDeviceBLL<DeviceReading>
    {
        //       public bool SaveModel(DeviceInput input)
        //{
        //    INoSqlDataAccess<Entity.DeviceInput> dataAccess = NoSqlBusinessModelFactory.CreateDeviceDataAccess();
        //    dataAccess.Save(input);
        //    return true;
        //}
        public bool Delete(DeviceReading reading)
        {
            throw new NotImplementedException();
        }

        public List<DeviceReading> GetAllReadings(string DeviceId)
        {
            INoSqlDataAccess<Entity.DeviceReading> dataAccess = NoSqlBusinessModelFactory.CreateDeviceDataAccess();
            return dataAccess.GetAllReadings(DeviceId);
        }

        public DeviceReading GetReading(string Id, string DeviceId)
        {
            INoSqlDataAccess<Entity.DeviceReading> dataAccess = NoSqlBusinessModelFactory.CreateDeviceDataAccess();
            return dataAccess.GetReading(Id,DeviceId);
        }

        public bool Save(DeviceReading reading)
        {
            INoSqlDataAccess<Entity.DeviceReading> dataAccess = NoSqlBusinessModelFactory.CreateDeviceDataAccess();
                dataAccess.Save(reading);
                return true;
        }

        public bool Update(DeviceReading reading)
        {
            throw new NotImplementedException();
        }

        
    }
}
