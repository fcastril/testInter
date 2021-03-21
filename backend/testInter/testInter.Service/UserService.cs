using System.Collections.Generic;
using testInter.Data;
using testInter.Repo;

namespace testInter.Service
{
    public class UserService : IUserService
    {

        private IRepository<User> userRepository;
        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;

        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }
        public User GetUser(int id)
        {
            return userRepository.Get(id);
        }
        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }
        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }
        public void DeleteUser(int id)
        {
            User user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }
    }
}
