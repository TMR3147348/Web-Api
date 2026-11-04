using Entity;

namespace Services
{
    public interface IUserService
    {
        void Delete(int id);
        IEnumerable<string> Get();
        int PostCheck(string password);
        User Get(int id);
        User Post(User user);
        User PostLogin(Login login);
        void Put(int id, User user);
    }
}