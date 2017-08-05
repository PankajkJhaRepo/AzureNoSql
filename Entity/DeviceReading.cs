using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class DeviceReading : BaseDocumentdb 
    {
        
      

        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("ReadingTime")]
        public DateTime ReadingTime;

        [JsonProperty("Value")]
        public string Value;

        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("QOutTime")]
        public DateTime QOutTime { get; set; }
    }
    
}
