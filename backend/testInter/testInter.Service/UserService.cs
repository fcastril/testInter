using System.Collections.Generic;
using testInter.Data;
using testInter.Repo;

namespace testInter.Service
{
    public class UserService : IUserService
    {

        private IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
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
        public User GetUser(string Email)
        {
            return userRepository.Get(Email);
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

        public User GetUser(string Email, string Password)
        {
            return userRepository.Get(Email, Password);
        }
    }
}
