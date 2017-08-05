using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DeviceInput: BaseAzureTableStorage
    {
        public DeviceInput()
        {
            
        }
        public string DeviceId { get; set; }

        public DateTime OriginTime { get; set; }

        public DateTime QOutTime { get; set; }

        public string Value { get; set; }
    }
}
