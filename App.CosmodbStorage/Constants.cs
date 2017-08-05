using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CosmodbStorage
{
   public static class Constants
    {
        public const string dbName = "DeviceDatadb";
        public const string DeviceCollectionName = "DeviceData";
        public const string DevicePartitionKeyName = "DeviceId";
    }
}
