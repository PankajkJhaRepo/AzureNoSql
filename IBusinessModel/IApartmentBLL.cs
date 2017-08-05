using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBusinessModel
{
   public interface IApartmentBLL<E>
        where E: class
    {
        List<E> GetAll();

        bool SaveModel(E entity);

        bool SaveBatch(List<E> entities);
    }
}
