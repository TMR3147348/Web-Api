using Entity;

namespace Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        void DeleteUser(int id);
        User GetUserById(int id);
        IEnumerable<string> GetUsers();
        User PostLogin(Login login);
        void UpdateUser(int id, User user);
    }
}