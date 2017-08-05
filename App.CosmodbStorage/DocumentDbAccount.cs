using Microsoft.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CosmodbStorage
{
   public class DocumentDbAccount
    {
        public static string GetDocumentdbEndPoint()
        {
            // Parse the connection string and return a reference to the storage account.
            return CloudConfigurationManager.GetSetting("CosmodbEndPoint");
        }
        public static string GetDocumentdbKey()
        {
            // Parse the connection string and return a reference to the storage account.
            return CloudConfigurationManager.GetSetting("CosmodbKey");
        }
    }
}
