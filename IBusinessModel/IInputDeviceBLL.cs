using System;
using System.Collections.Generic;
using System.Text;

namespace IBusinessModel
{
    public interface IInputDeviceBLL<E>
        where E : class
    {
        List<E> GetAll();

        bool SaveModel(E input);

        bool SaveBatch(List<E> inputs);
    }
}
