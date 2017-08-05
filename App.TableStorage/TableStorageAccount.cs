using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;

namespace App.TableStorage
{
    public class TableStorageAccount
    {
        public static CloudStorageAccount GetCloudStorageAccount()
        {
            // Parse the connection string and return a reference to the storage account.
            return CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
        }
    }
}
