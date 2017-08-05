using BusinessModel.Factory;
using Entity;
using IBusinessModel;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessModel.Apartment
{
    public class ApartmentBLL<T> : IApartmentBLL<Entity.Apartment>
    {
        public List<Entity.Apartment> GetAll()
        {
            // IApartmentDataAccess<Entity.Apartment> dataAccess = NoSqlBusinessModelFactory.CreateApartmentDataAccess();
            IEFDataAccess<Entity.Apartment> dataAccess = EFBusinessModelFactory.CreateApartmentDataAccess();
            return dataAccess.GetAll();
        }

        public bool SaveBatch(List<Entity.Apartment> entities)
        {
            throw new NotImplementedException();
        }

        public bool SaveModel(Entity.Apartment entity)
        {

            //  IApartmentDataAccess<Entity.Apartment> dataAccess = NoSqlBusinessModelFactory.CreateApartmentDataAccess();
            IEFDataAccess<Entity.Apartment> dataAccess = EFBusinessModelFactory.CreateApartmentDataAccess();
            dataAccess.Save(entity);
            return true;
        }
    }
}
