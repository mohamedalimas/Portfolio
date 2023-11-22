using Core.Interfaces.Repository;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DataContext db;
        private DbSet<T> dbSet;
        public GenericRepo(DataContext db)
        {
            this.db = db;
            dbSet=db.Set<T>();
        }
        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public void Update(T item)
        {
            dbSet.Update(item);
        }
    }
}
