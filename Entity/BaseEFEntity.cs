using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BaseEFEntity
    {
        public BaseEFEntity()
        {
            this.ID = Guid.NewGuid();
        }
        public Guid ID
        {
            get;
            set;
        }
       
    }
}

