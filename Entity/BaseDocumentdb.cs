using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class BaseDocumentdb
    {
        [JsonProperty("DeviceId")]
        public string DeviceId;

        [JsonProperty("Id")]
        public string Id;

    }
}
