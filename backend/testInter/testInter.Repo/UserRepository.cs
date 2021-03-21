using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using testInter.Data;
using testInter.Repo.Security;

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
            var list = entities.AsEnumerable();
            foreach (var item in list)
            {
                item.Email = Crypto.Decrypt(item.Email);
                item.UserName = Crypto.Decrypt(item.UserName);
            }
            return list;
        }
        public User Get(int id)
        {
            var data = entities.SingleOrDefault(s => s.Id == id);
            //data.Email = Crypto.Decrypt(data.Email);
            //data.UserName = Crypto.Decrypt(data.UserName);

            return data;
        }
        public User Get(string Email)
        {
            var data = entities.SingleOrDefault(s => s.Email == Crypto.Encrypt(Email));
            data.Email = Crypto.Decrypt(data.Email);
            data.UserName = Crypto.Decrypt(data.UserName);

            return data;
        }
        public void Insert(User reg)
        {
            if (reg == null)
            {
                throw new System.ArgumentNullException("reg");
            }

            reg.UserName = Crypto.Encrypt(reg.UserName);
            reg.Email = Crypto.Encrypt(reg.Email);
            reg.Password = Crypto.Encrypt(reg.Password);

            entities.Add(reg);
            context.SaveChanges();
        }
        public void Update(User reg)
        {
            if (reg == null)
            {
                throw new System.ArgumentNullException("reg");
            }

            reg.UserName = Crypto.Encrypt(reg.UserName);
            reg.Email = Crypto.Encrypt(reg.Email);
            reg.Password = Crypto.Encrypt(reg.Password);
            context.Update(reg);
            context.SaveChanges();
        }
        public void Delete(User reg)
        {
            if (reg == null)
            {
                throw new System.ArgumentNullException("reg");
            }

            reg.UserName = Crypto.Encrypt(reg.UserName);
            reg.Email = Crypto.Encrypt(reg.Email);
            reg.Password = Crypto.Encrypt(reg.Password);
            entities.Remove(reg);
            context.SaveChanges();
        }

        public void Remove(User reg)
        {
            if (reg == null)
            {
                throw new System.ArgumentNullException("reg");
            }

            reg.UserName = Crypto.Encrypt(reg.UserName);
            reg.Email = Crypto.Encrypt(reg.Email);
            reg.Password = Crypto.Encrypt(reg.Password);
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
