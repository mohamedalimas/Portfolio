using Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepo<T> Repository { get; }
        public void Commit();
    }
}
