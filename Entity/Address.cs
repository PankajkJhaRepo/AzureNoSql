using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Address : BaseEFEntity
    {
        public Address()
        {
            
        }
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string LandMark { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PinCode { get; set; }
    }
}
