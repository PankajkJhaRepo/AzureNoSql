using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Apartment : BaseEFEntity
    {
        public Apartment()
        {
            
        }
        public string ApartmentName
        {
            get;
            set;
        }
        public string ApartmentCaption
        {
            get;
            set;
        }

        public Guid AddressId
        {
            get;set;
        }
        public Address Address
        {
            get; set;
        }
    }
}
