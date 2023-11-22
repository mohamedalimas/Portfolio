using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repository
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(Object id);
        void Add (T item);
        void Delete (T item);
        void Update (T item);
    }
}
