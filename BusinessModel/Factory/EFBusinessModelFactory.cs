using EFDataAccess.BusinessContext;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Factory
{
  public  class EFBusinessModelFactory
    {
        public static IEFDataAccess<Entity.Apartment> CreateApartmentDataAccess()
        {
            IEFDataAccess<Entity.Apartment> DataAccess = new ApartmentDataAccess<Entity.Apartment>();

            return DataAccess;

        }
    }
}
