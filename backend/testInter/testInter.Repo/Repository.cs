using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using testInter.Data;

namespace testInter.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly testInterContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(testInterContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            entities.Add(reg);
            context.SaveChanges();
        }
        public void Update(T reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            context.SaveChanges();
        }
        public void Delete(T reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            entities.Remove(reg);
            context.SaveChanges();
        }

        public void Remove(T reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            entities.Remove(reg);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
