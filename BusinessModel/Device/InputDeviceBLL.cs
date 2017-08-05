using IBusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDataAccess;
using BusinessModel.Factory;

namespace BusinessModel.Device
{
    public class InputDeviceBLL<T> : IInputDeviceBLL<DeviceInput>
    {
        public List<DeviceInput> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool SaveBatch(List<DeviceInput> inputs)
        {
            throw new NotImplementedException();
        }

        public bool SaveModel(DeviceInput input)
        {
           // INoSqlDataAccess<Entity.DeviceInput> dataAccess = NoSqlBusinessModelFactory.CreateDeviceDataAccess();
            //dataAccess.Save(input);
            return true;
        }
    }
}
