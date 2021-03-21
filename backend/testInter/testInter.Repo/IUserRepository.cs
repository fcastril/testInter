using System.Collections.Generic;
using testInter.Data;

namespace testInter.Repo
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User Get(string username, string password);
        User Get(string username);
        void Insert(User reg);
        void Update(User reg);
        void Delete(User reg);
        void Remove(User reg);
        void SaveChanges();
    }
}
