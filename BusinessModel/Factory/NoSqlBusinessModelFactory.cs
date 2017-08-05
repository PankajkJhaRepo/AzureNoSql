using IDataAccess;
using NoSqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Factory
{
    public class NoSqlBusinessModelFactory
    {
        public static INoSqlDataAccess<Entity.DeviceReading> CreateDeviceDataAccess()
        {
            INoSqlDataAccess<Entity.DeviceReading> DataAccess = new DeviceReadingDataAccess<Entity.DeviceReading>();

            return DataAccess;

        }
    }
}
