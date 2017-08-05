using Entity;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.BusinessContext
{
    public class ApartmentDataAccess<T> : IEFDataAccess<Apartment>
    {
        EFDataAccess.EFDbContext context = new EFDbContext();
        public List<Apartment> GetAll()
        {
            return context.Apartments.ToList();
        }

        public bool SaveBatch(List<BaseAzureTableStorage> entities)
        {
            return true;
        }

        public bool SaveBatch(List<Apartment> entities)
        {
            throw new NotImplementedException();
        }

        public bool Save(Apartment entity)
        {
            context.Apartments.Add(entity);
            context.SaveChanges();
            return true;
        }
    }
}
