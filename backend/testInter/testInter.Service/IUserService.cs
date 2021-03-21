using System.Collections.Generic;
using testInter.Data;

namespace testInter.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
