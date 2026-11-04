using System.Runtime.InteropServices;
using System.Text.Json;
using Entity;
using Repository;
using Zxcvbn;
namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository repository;
       public  UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        

        public IEnumerable<string> Get()
        {
            return repository.GetUsers();
        }

        public User Get(int id)
        {
            return repository.GetUserById(id);
        }

        public int PostCheck(string password)
        {
            if (password == null)
                return 0;
            var result = Core.EvaluatePassword(password);
            int score = result.Score;
            return score;
        }

        public User PostLogin(Login login)
        {
            return repository.PostLogin(login);
        }

        public User Post(User user)
        {
            return repository.AddUser(user);
        }

        public void Put(int id, User user)
        {
            repository.UpdateUser(id, user);
        }

        public void Delete(int id)
        {
        }


    }

}

