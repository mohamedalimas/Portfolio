using Core.Interfaces.Repository;
using Core.Interfaces.UnitOfWork;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DataContext db;
        private IGenericRepo<T>? repo;
        public IGenericRepo<T> Repository
        {
            get
            {
                return repo ?? (repo = new GenericRepo<T>(db));
            }
        }

        public UnitOfWork(DataContext db)
        {
            this.db = db;
        }
        public void Commit()
        {
            db.SaveChanges();
        }
    }
}
