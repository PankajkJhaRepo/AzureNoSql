using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBusinessModel
{
    public interface IBusinessModelContext<T,E>
        where T: class
        where E : BaseAzureTableStorage
    {
        IEnumerable<E> GetAll();

        bool SaveModel(E entity);

        bool SaveBatch(IEnumerable<E> entities);
    }
}
