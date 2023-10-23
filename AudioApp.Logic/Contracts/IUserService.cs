using AudioApp.Model;

namespace AudioApp.Logic.Contracts;

public interface IUserService
{
    public IEnumerable<User> GetList();
    public User Get(int id);
    public User Create(User newUser);
    public User Update(int id, User user);
    public bool Delete(int id);

}