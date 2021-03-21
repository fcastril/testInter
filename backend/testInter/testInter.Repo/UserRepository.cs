using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using testInter.Data;

namespace testInter.Repo
{
    public class UserRepository : IUserRepository
    {

        private readonly testInterContext context;
        private DbSet<User> entities;
        string errorMessage = string.Empty;

        public UserRepository(testInterContext context)
        {
            this.context = context;
            entities = context.Set<User>();
        }
        public IEnumerable<User> GetAll()
        {
            return entities.AsEnumerable();
        }
        public User Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(User reg)
        {
            if (reg == null)
            {
                throw new System.ArgumentNullException("reg");
            }
            entities.Add(reg);
            context.SaveChanges();
        }
        public void Update(User reg)
        {
            if (reg == null)
            {
                throw new System.ArgumentNullException("reg");
            }
            context.SaveChanges();
        }
        public void Delete(User reg)
        {
            if (reg == null)
            {
                throw new System.ArgumentNullException("reg");
            }
            entities.Remove(reg);
            context.SaveChanges();
        }

        public void Remove(User reg)
        {
            if (reg == null)
            {
                throw new System.ArgumentNullException("reg");
            }
            entities.Remove(reg);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public User Get(string Email, string Password)
        {
            return entities.Where(u => u.Email == Security.Crypto.Encrypt(Email) && u.Password == Security.Crypto.Encrypt(Password)).SingleOrDefault();
        }

       
    }
}
