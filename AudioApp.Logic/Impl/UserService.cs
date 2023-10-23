using AudioApp.DAL;
using AudioApp.Logic.Contracts;
using AudioApp.Model;

namespace AudioApp.Logic.Impl;

public class UserService : IUserService
{
    readonly AudioAppContext _dbContext;
    public UserService(AudioAppContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<User> GetList()
     => _dbContext.Users.ToArray();

    public User Get(int id)
    {
        throw new NotImplementedException();
    }


    public User Create(User newUser)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public User Update(int id, User user)
    {
        throw new NotImplementedException();
    }
}
